# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Commands

```bash
# Build
dotnet build VaultReviewer/VaultReviewer.csproj

# Run
dotnet run --project VaultReviewer/VaultReviewer.csproj

# Publish standalone executable
dotnet publish VaultReviewer/VaultReviewer.csproj -c Release -o publish/
```

No test suite is configured.

## Architecture

**VaultReviewer** is a .NET 10 Windows Forms tray app that randomly selects Markdown files from an Obsidian vault for daily review, tracking history to avoid repetition until all files are seen.

### Project structure

```
VaultReviewer/
├── Forms/
│   ├── ReviewDashboard.cs / .Designer.cs / .resx   ← main window
│   └── SettingsForm.cs / .Designer.cs               ← settings dialog
├── Core/
│   ├── VaultReviewer.cs      ← business logic
│   ├── VaultReviewerData.cs  ← data models
│   └── Config.cs             ← config model
└── Program.cs
```

Namespaces: `VaultReviewer.Forms` and `VaultReviewer.Core`.  
`VaultReviewer` (class) conflicts with the root namespace — `ReviewDashboard.cs` imports it via alias: `using ReviewEngine = VaultReviewer.Core.VaultReviewer`.

### Layer breakdown

| File | Role |
|------|------|
| `Program.cs` | Entry point — boots WinForms with `ReviewDashboard` |
| `Forms/ReviewDashboard` | Borderless main window with dark theme; tray icon, drag-to-move header, ⚙ settings and ✕ close buttons, dynamic checkbox list |
| `Forms/SettingsForm` | Modal dialog for `UserName` and `ReviewsPerDay` |
| `Core/VaultReviewer` | Core logic — scans vault, draws daily selections, tracks history, loads/saves state and config |
| `Core/VaultReviewerData` | `VaultRegisters` (single review entry) + `VaultReviewerData` (full state container) |
| `Core/Config` | `ReviewsPerDay` (default 5) + `UserName` (default empty) |

### Data persistence

All state is stored under `%APPDATA%\VaultReviewer\`:
- `data.json` — vault path, today's picks, review history
- `config.json` — `ReviewsPerDay`, `UserName`

### UI design

- **Borderless window** (`FormBorderStyle.None`) with a custom dark theme (Catppuccin Mocha palette).
- **Header panel** (`#181825`): title label left, ⚙ at x=340, ✕ at x=388. Buttons must NOT use `Anchor = Right` — the panel has no size at init time, which pushes anchored controls off-screen.
- **Content panel** (`#1E1E2E`): checkboxes added dynamically by `PopulateReviews`; form height resizes to fit.
- **Drag**: `panelHeader` and `lblTitle` use P/Invoke (`ReleaseCapture` + `SendMessage WM_NCLBUTTONDOWN`) wired in `ReviewDashboard_Load`.
- **Title**: `GetDisplayTitle()` returns `"{UserName}'s Homework"` or `"Homework"` if name is empty. Refreshed on load and after settings dialog closes.
- **Tray context menu**: Open / Quit. ✕ button hides the window (app stays in tray); Quit exits fully.

### Constructor order

`InitializeComponent()` must be called **before** `new ReviewEngine(this)` in `ReviewDashboard()` — the engine calls `PopulateReviews` during construction, which requires `panelContent` to already exist.

### Core workflow

1. On first run, user selects an Obsidian vault folder.
2. `VaultReviewer.ScanVault()` recursively collects all `.md` files.
3. `DrawReviews()` / `DrawNewReview()` randomly pick N files from the unreviewed pool.
4. User marks files reviewed via checkboxes.
5. When all vault files are reviewed, history clears and a new cycle begins.
6. New selections are generated once per calendar day.
