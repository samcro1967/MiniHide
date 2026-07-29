namespace MiniHide.Models;

public sealed class AppSettings
{
    public bool StartWithWindows { get; set; } = true;

    public bool StartMinimized { get; set; } = true;

    public bool ConfirmBeforeHiding { get; set; } = false;

    // Hide Window Hotkey (Win + End)
    public uint HideHotkeyModifiers { get; set; } = 0x0008; // Win

    public uint HideHotkeyVirtualKey { get; set; } = 0x23; // End

    // Restore All Hotkey (Ctrl + Win + End)
    public uint RestoreHotkeyModifiers { get; set; } = 0x0002 | 0x0008; // Ctrl + Win

    public uint RestoreHotkeyVirtualKey { get; set; } = 0x23; // End

    public List<string> ExcludedProcesses { get; set; } =
    [
        "explorer",
        "Taskmgr"
    ];

    public HotkeySettings Hotkeys =>
        new(
            HideHotkeyModifiers,
            HideHotkeyVirtualKey,
            RestoreHotkeyModifiers,
            RestoreHotkeyVirtualKey);
}


