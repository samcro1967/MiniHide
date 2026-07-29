/*
 * File: HotkeyValidator.cs
 * Path: /Helpers/HotkeyValidator.cs
 *
 * Purpose:
 * Validate global hotkey combinations before attempting to register them
 * with Windows. Detect well-known Windows-reserved shortcuts and prevent
 * duplicate MiniHide hotkey assignments.
 */

using System.Windows.Forms;

namespace MiniHide.Helpers;

public static class HotkeyValidator
{
    private const uint MOD_ALT = 0x0001;
    private const uint MOD_CONTROL = 0x0002;
    private const uint MOD_SHIFT = 0x0004;
    private const uint MOD_WIN = 0x0008;

    /// <summary>
    /// Returns true if the requested pair of hotkeys is allowed.
    /// If false, reason contains a user-friendly explanation.
    /// </summary>
    public static bool Validate(
        uint hideModifiers,
        uint hideVirtualKey,
        uint restoreModifiers,
        uint restoreVirtualKey,
        out string? reason)
    {
        reason = null;

        if (hideModifiers == restoreModifiers &&
            hideVirtualKey == restoreVirtualKey)
        {
            reason =
                "The Hide Window and Restore All hotkeys must be different.";

            return false;
        }

        if (IsReservedByWindows(
                hideModifiers,
                hideVirtualKey,
                out reason))
        {
            return false;
        }

        if (IsReservedByWindows(
                restoreModifiers,
                restoreVirtualKey,
                out reason))
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// Detects well-known Windows-reserved shortcuts.
    /// </summary>
    private static bool IsReservedByWindows(
        uint modifiers,
        uint virtualKey,
        out string? reason)
    {
        reason = null;

        bool hasWindowsKey =
            (modifiers & MOD_WIN) != 0;

        if (!hasWindowsKey)
        {
            return false;
        }

        Keys key = (Keys)virtualKey;

        switch (key)
        {
            case Keys.D:
                reason =
                    "Windows + D is reserved by Windows to show the desktop.";
                return true;

            case Keys.E:
                reason =
                    "Windows + E is reserved by Windows Explorer.";
                return true;

            case Keys.I:
                reason =
                    "Windows + I is reserved by Windows Settings.";
                return true;

            case Keys.L:
                reason =
                    "Windows + L is reserved by Windows to lock the computer.";
                return true;

            case Keys.R:
                reason =
                    "Windows + R is reserved by the Run dialog.";
                return true;

            case Keys.Tab:
                reason =
                    "Windows + Tab is reserved by Task View.";
                return true;

            case Keys.V:
                reason =
                    "Windows + V is reserved by Clipboard History.";
                return true;

            case Keys.X:
                reason =
                    "Windows + X is reserved by the Power User menu.";
                return true;
        }

        return false;
    }
}


