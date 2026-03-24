# VaultReviewer

VaultReviewer is a lightweight tray utility designed to support daily study and knowledge review workflows.

The tool scans an Obsidian vault and randomly selects a Markdown file (`.md`) for review each day. It keeps track of recently reviewed files to ensure that the same document is not repeated until all other files in the vault have been reviewed.

This guarantees a complete review cycle across your knowledge base before restarting.

## Features

- Scans a selected Obsidian vault
- Randomly selects a document for daily review
- Prevents repetition until all documents have been reviewed
- Stores review history locally
- Runs silently in the system tray
- Automatically resumes review progress between sessions

## How it works

1. Select your Obsidian vault directory
2. The application scans all `.md` files
3. A file is randomly selected for review
4. Reviewed files are tracked
5. Files are not repeated until the full vault has been covered

Once every file has been reviewed, a new cycle begins automatically.

## Purpose

VaultReviewer was created as a personal study-support tool to reinforce long-term retention by encouraging continuous exposure to previously written notes.

It is especially useful for developers, students, and knowledge workers maintaining structured note systems inside an Obsidian vault.

## Future improvements (planned)

- Configurable number of daily review files (now it's just 2)
- Daily notification reminders
- Review statistics
- Multiple vault support
- Optional spaced repetition logic

## License

Personal utility project. License may be added later.