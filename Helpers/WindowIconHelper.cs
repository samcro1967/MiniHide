using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;

using MiniHide.Native;

namespace MiniHide.Helpers;

internal static class WindowIconHelper
{
    private const uint WM_GETICON = 0x007F;

    private const int ICON_SMALL = 0;
    private const int ICON_BIG = 1;
    private const int ICON_SMALL2 = 2;

    private const int GCLP_HICON = -14;
    private const int GCLP_HICONSM = -34;

    public static Image? GetWindowIcon(
        IntPtr hwnd,
        Process process)
    {
        IntPtr hIcon =
            GetIconHandle(hwnd);

        if (hIcon != IntPtr.Zero)
        {
            using Icon icon =
                (Icon)Icon.FromHandle(hIcon).Clone();

            return icon.ToBitmap();
        }

        try
        {
            Icon? icon =
                Icon.ExtractAssociatedIcon(
                    process.MainModule!.FileName);

            return icon?.ToBitmap();
        }
        catch
        {
            return null;
        }
    }

    private static IntPtr GetIconHandle(
        IntPtr hwnd)
    {
        IntPtr hIcon =
            NativeMethods.SendMessage(
                hwnd,
                WM_GETICON,
                (IntPtr)ICON_SMALL2,
                IntPtr.Zero);

        if (hIcon != IntPtr.Zero)
            return hIcon;

        hIcon =
            NativeMethods.SendMessage(
                hwnd,
                WM_GETICON,
                (IntPtr)ICON_SMALL,
                IntPtr.Zero);

        if (hIcon != IntPtr.Zero)
            return hIcon;

        hIcon =
            NativeMethods.SendMessage(
                hwnd,
                WM_GETICON,
                (IntPtr)ICON_BIG,
                IntPtr.Zero);

        if (hIcon != IntPtr.Zero)
            return hIcon;

        hIcon =
            NativeMethods.GetClassLongPtr(
                hwnd,
                GCLP_HICONSM);

        if (hIcon != IntPtr.Zero)
            return hIcon;

        return NativeMethods.GetClassLongPtr(
            hwnd,
            GCLP_HICON);
    }
}


