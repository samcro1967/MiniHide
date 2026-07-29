namespace MiniHide.Models;

public sealed record HotkeySettings(
    uint HideModifiers,
    uint HideVirtualKey,
    uint RestoreModifiers,
    uint RestoreVirtualKey);


