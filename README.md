# MiniHide

MiniHide is a lightweight Windows tray utility for hiding and restoring application windows.

It allows you to quickly hide any active window and restore it later using global hotkeys.

---

## Features

- Hide the active window using a global hotkey
- Restore individual hidden windows
- Restore all hidden windows
- Runs from the Windows system tray
- Configurable global hotkeys
- Start with Windows option
- Start minimized
- Lightweight, fast, and self-contained
- Built with .NET 10 WinForms

---

## Installation

1. Download the latest MiniHideSetup.exe
2. Run the installer
3. Launch MiniHide (runs in system tray)

---

## Usage

### Default Behavior

- Press the configured hotkey to hide the active window
- Use the tray menu to restore windows

### Tray Menu

- Restore individual windows
- Restore all windows
- Open settings
- Exit application

---

## Settings

Settings are stored at:

%LOCALAPPDATA%\MiniHide\settings.json

You can modify settings manually:

1. Close MiniHide
2. Edit settings.json
3. Restart MiniHide

---

## Building

Requirements:

- Visual Studio 2026 or later
- .NET 10 SDK

Open the solution and build the project.

---

## License

MiniHide is licensed under the MIT License.

See LICENSE for details.

---

## Author

Copyright © 2026 samcro1967