using MiniHide.Native;

namespace MiniHide.Managers;

public sealed class HotkeyManager : IDisposable
{
    private readonly IntPtr windowHandle;

    private readonly int hotkeyId;

    private readonly uint modifiers;

    private readonly uint virtualKey;

    public HotkeyManager(
        IntPtr windowHandle,
        int hotkeyId,
        uint modifiers,
        uint virtualKey)
    {
        this.windowHandle = windowHandle;
        this.hotkeyId = hotkeyId;
        this.modifiers = modifiers;
        this.virtualKey = virtualKey;
    }

    public void Register()
    {
        if (!NativeMethods.RegisterHotKey(
            windowHandle,
            hotkeyId,
            modifiers,
            virtualKey))
        {
            throw new InvalidOperationException(
                "Failed to register the configured hotkey. It may already be in use or reserved by Windows.");
        }
    }

    public void Dispose()
    {
        NativeMethods.UnregisterHotKey(
            windowHandle,
            hotkeyId);
    }
}


