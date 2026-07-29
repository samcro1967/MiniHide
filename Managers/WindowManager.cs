using System.Diagnostics;
using System.Text;

using MiniHide.Models;
using MiniHide.Native;
using MiniHide.Helpers;

using System.Collections.ObjectModel;
using System.Linq;

namespace MiniHide.Managers;

public sealed class WindowManager
{

    private readonly List<ManagedWindow> managedWindows = [];

    public ReadOnlyCollection<ManagedWindow> ManagedWindows =>
        managedWindows.AsReadOnly();

    public ManagedWindow? GetActiveWindow()
    {
        IntPtr hwnd = NativeMethods.GetForegroundWindow();

        if (hwnd == IntPtr.Zero)
            return null;

        StringBuilder title = new(512);

        NativeMethods.GetWindowText(
            hwnd,
            title,
            title.Capacity);

        StringBuilder className = new(256);

        NativeMethods.GetClassName(
            hwnd,
            className,
            className.Capacity);

        NativeMethods.GetWindowThreadProcessId(
            hwnd,
            out uint pid);

        Process process = Process.GetProcessById((int)pid);

        return new ManagedWindow
        {
            Handle = hwnd,
            Title = title.ToString(),
            ProcessId = pid,
            ProcessName = process.ProcessName,
            ClassName = className.ToString(),
            Icon = WindowIconHelper.GetWindowIcon(
                hwnd,
                process)
        };
    }

    public bool CanManageWindow(ManagedWindow window)
    {
        if (window.Handle == IntPtr.Zero)
            return false;

        if (!NativeMethods.IsWindow(window.Handle))
            return false;

        if (!NativeMethods.IsWindowVisible(window.Handle))
            return false;

        if (string.IsNullOrWhiteSpace(window.Title))
            return false;

        if (window.ProcessId == (uint)Environment.ProcessId)
            return false;

        if (window.Handle == NativeMethods.GetDesktopWindow())
            return false;

        if (window.Handle == NativeMethods.GetShellWindow())
            return false;

        switch (window.ClassName)
        {
            case "Shell_TrayWnd":
            case "Progman":
            case "WorkerW":
                return false;
        }

        return true;
    }

    public bool AddManagedWindow(ManagedWindow window)
    {
        if (managedWindows.Any(w => w.Handle == window.Handle))
            return false;

        managedWindows.Add(window);

        return true;
    }

    public bool RemoveManagedWindow(IntPtr handle)
    {
        ManagedWindow? window =
            managedWindows.FirstOrDefault(w => w.Handle == handle);

        if (window == null)
            return false;

        managedWindows.Remove(window);

        return true;
    }

    public bool IsManaged(IntPtr handle)
    {
        return managedWindows.Any(w => w.Handle == handle);
    }

    public bool HideWindow(ManagedWindow window)
    {
        if (!NativeMethods.IsWindow(window.Handle))
            return false;

        if (!NativeMethods.IsWindowVisible(window.Handle))
            return false;

        return NativeMethods.ShowWindow(
            window.Handle,
            NativeMethods.SW_HIDE);
    }

    public bool RestoreWindow(ManagedWindow window)
    {
        if (!NativeMethods.IsWindow(window.Handle))
            return false;

        return NativeMethods.ShowWindow(
            window.Handle,
            NativeMethods.SW_RESTORE);
    }

    public void RestoreAllWindows()
    {
        foreach (ManagedWindow window in managedWindows.ToList())
        {
            RestoreWindow(window);
        }

        managedWindows.Clear();
    }
}


