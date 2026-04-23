# VaultReviewer

A lightweight Windows tray app that picks a random set of Markdown files from your [Obsidian](https://obsidian.md) vault every day and asks you to review them — so you gradually revisit everything you've ever written, without repeating yourself until the full cycle is complete.

## Features

- Randomly selects N files from your vault each day
- Tracks review history — a file won't appear again until every other file has been seen
- Checkbox UI to mark each file as reviewed
- Ignore list — exclude specific folders or files from the selection pool
- Configurable number of daily reviews and display name
- Lives in the system tray; starts with Windows automatically
- Dark theme (Catppuccin Mocha)

## Requirements

- Windows 10/11
- [.NET 10 Runtime](https://dotnet.microsoft.com/download/dotnet/10.0) (or use the self-contained publish)

## Getting Started

1. Launch the app — on first run it will ask you to select your Obsidian vault folder.
2. The main window shows today's picks as checkboxes. Check them off as you review each file.
3. The window hides to the tray when closed; double-click the tray icon to reopen it.

## Settings

Click the ⚙ button to open Settings:

| Option | Description |
|--------|-------------|
| Your name | Personalizes the window title to `{Name}'s Homework` |
| Reviews per day | How many files are picked each day (default: 5) |
| Ignored folders / files | Paths excluded from the selection pool — add entire folders or individual files |

Changes take effect the next time daily picks are drawn.

## Data

All state is stored in `%APPDATA%\VaultReviewer\`:

| File | Contents |
|------|----------|
| `data.json` | Vault path, today's picks, review history |
| `config.json` | `ReviewsPerDay`, `UserName`, `IgnoredPaths` |

## Building

```bash
# Debug build
dotnet build VaultReviewer/VaultReviewer.csproj

# Run
dotnet run --project VaultReviewer/VaultReviewer.csproj
```

## Publishing

Run `publish.bat` as Administrator (it self-elevates) and enter the destination folder when prompted. The script clears the folder before publishing so the output is always clean.

```
publish.bat
> Destination folder: C:\Program Files\VaultReviewer
```

Or manually:

```bash
dotnet publish VaultReviewer/VaultReviewer.csproj -c Release -o <destination>
```
