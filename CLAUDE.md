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

### Layer breakdown

| File | Role |
|------|------|
| `Program.cs` | Entry point — boots WinForms with `Form1` |
| `Form1.cs` | UI + tray integration; handles vault path selection, checkbox rendering, minimize-to-tray, and Windows startup registration (via `HKCU\...\Run`) |
| `VaultReviewer.cs` | Core logic — scans vault, draws daily selections, tracks history, loads/saves state |
| `VaultReviewerData.cs` | Data models: `VaultRegisters` (single review entry), `VaultReviewerData` (full state container) |
| `Config.cs` | Settings model — currently just `ReviewsPerDay` (default: 5) |

### Data persistence

All state is stored under `%APPDATA%\VaultReviewer\`:
- `data.json` — current session state (vault path, today's picks, review history)
- `config.json` — user preferences

### Core workflow

1. On first run, user selects an Obsidian vault folder.
2. `VaultReviewer.ScanVault()` recursively collects all `.md` files.
3. `DrawReviews()` / `DrawNewReview()` randomly pick N files from the unreviewed pool.
4. User marks files reviewed via checkboxes in `Form1`.
5. When all vault files are reviewed, history clears and a new cycle begins.
6. New selections are generated once per calendar day.
