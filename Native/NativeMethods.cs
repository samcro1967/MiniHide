using System.Runtime.InteropServices;
using System.Text;

namespace MiniHide.Native;

internal static class NativeMethods
{
    public const int WM_HOTKEY = 0x0312;

    public const uint MOD_WIN = 0x0008;

    public const int SW_HIDE = 0;
    public const int SW_SHOW = 5;
    public const int SW_RESTORE = 9;

    public static readonly int WM_TASKBARCREATED =
        RegisterWindowMessage("TaskbarCreated");

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    public static extern int RegisterWindowMessage(
        string lpString);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool RegisterHotKey(
        IntPtr hWnd,
        int id,
        uint fsModifiers,
        uint vk);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool UnregisterHotKey(
        IntPtr hWnd,
        int id);

    [DllImport("user32.dll")]
    public static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    public static extern int GetWindowText(
        IntPtr hWnd,
        StringBuilder text,
        int count);

    [DllImport("user32.dll")]
    public static extern uint GetWindowThreadProcessId(
    IntPtr hWnd,
    out uint processId);

    [DllImport("user32.dll")]
    public static extern bool IsWindow(
        IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern bool ShowWindow(
    IntPtr hWnd,
    int nCmdShow);

    [DllImport("user32.dll")]
    public static extern bool IsWindowVisible(
        IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern IntPtr GetShellWindow();

    [DllImport("user32.dll")]
    public static extern IntPtr GetDesktopWindow();

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    public static extern int GetClassName(
        IntPtr hWnd,
        StringBuilder className,
        int maxCount);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessage(
        IntPtr hWnd,
        uint msg,
        IntPtr wParam,
        IntPtr lParam);

    [DllImport("user32.dll", EntryPoint = "GetClassLongPtr", SetLastError = true)]
    private static extern IntPtr GetClassLongPtr64(
        IntPtr hWnd,
        int nIndex);

    [DllImport("user32.dll", EntryPoint = "GetClassLong", SetLastError = true)]
    private static extern uint GetClassLong32(
        IntPtr hWnd,
        int nIndex);

    public static IntPtr GetClassLongPtr(
        IntPtr hWnd,
        int nIndex)
    {
        if (IntPtr.Size == 8)
        {
            return GetClassLongPtr64(
                hWnd,
                nIndex);
        }

        return new IntPtr(
            unchecked((int)GetClassLong32(
                hWnd,
                nIndex)));
    }

}



