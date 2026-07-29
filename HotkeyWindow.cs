using System.Windows.Forms;

namespace MiniHide;

internal sealed class HotkeyWindow : NativeWindow, IDisposable
{
    public event Action<Message>? HotkeyPressed;

    public HotkeyWindow()
    {
        CreateHandle(new CreateParams());
    }

    protected override void WndProc(ref Message m)
    {
        const int WM_HOTKEY = 0x0312;

        if (m.Msg == WM_HOTKEY)
        {
            HotkeyPressed?.Invoke(m);
        }

        base.WndProc(ref m);
    }

    public void Dispose()
    {
        DestroyHandle();
    }
}



