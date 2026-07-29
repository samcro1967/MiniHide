using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using MiniHide.Models;

namespace MiniHide.Helpers;

public static class DiagnosticsBuilder
{
    public static string Build(
        AppSettings settings,
        IReadOnlyCollection<ManagedWindow> windows)
    {
        StringBuilder sb = new();

        sb.AppendLine("=== MiniHide Diagnostics ===");
        sb.AppendLine();

        // --------------------------------------------------
        // Time
        // --------------------------------------------------
        sb.AppendLine("Time:");
        sb.AppendLine(DateTime.Now.ToString());
        sb.AppendLine($"Timezone: {TimeZoneInfo.Local.DisplayName}");
        sb.AppendLine();

        // --------------------------------------------------
        // App Info
        // --------------------------------------------------
        sb.AppendLine("App:");
        var appVersion =
            typeof(DiagnosticsBuilder)
                .Assembly
                .GetName()
                .Version;

        string versionText = appVersion == null
            ? "Unknown"
            : $"{appVersion.Major}.{appVersion.Minor}.{appVersion.Build}";

        sb.AppendLine($"Version: {versionText}");
        sb.AppendLine($"Executable: {Application.ExecutablePath}");
        sb.AppendLine();

        // --------------------------------------------------
        // Paths
        // --------------------------------------------------
        sb.AppendLine("Paths:");
        sb.AppendLine($"Current Directory: {Environment.CurrentDirectory}");
        sb.AppendLine();

        // --------------------------------------------------
        // Windows Info (Friendly)
        // --------------------------------------------------
        var (edition, version, build) = GetWindowsInfo();

        sb.AppendLine("Windows:");
        sb.AppendLine($"Edition: {edition}");
        sb.AppendLine($"Version: {version}");
        sb.AppendLine($"Build: {build}");
        sb.AppendLine($"Description: {RuntimeInformation.OSDescription}");
        sb.AppendLine();

        // --------------------------------------------------
        // Environment
        // --------------------------------------------------
        sb.AppendLine("Environment:");
        sb.AppendLine($"Machine: {Environment.MachineName}");
        sb.AppendLine($"User: {Environment.UserName}");
        sb.AppendLine($"64-bit OS: {Environment.Is64BitOperatingSystem}");
        sb.AppendLine($"64-bit Process: {Environment.Is64BitProcess}");
        sb.AppendLine();

        // --------------------------------------------------
        // Display
        // --------------------------------------------------
        var screen = Screen.PrimaryScreen;

        if (screen != null)
        {
            sb.AppendLine("Display:");
            sb.AppendLine($"Resolution: {screen.Bounds.Width}x{screen.Bounds.Height}");
            sb.AppendLine($"Working Area: {screen.WorkingArea.Width}x{screen.WorkingArea.Height}");
            sb.AppendLine();
        }

        // --------------------------------------------------
        // Startup / Settings
        // --------------------------------------------------
        sb.AppendLine("Startup:");
        sb.AppendLine($"StartWithWindows: {settings.StartWithWindows}");
        sb.AppendLine($"StartMinimized: {settings.StartMinimized}");
        sb.AppendLine();

        // --------------------------------------------------
        // Hotkeys
        // --------------------------------------------------
        sb.AppendLine("Hotkeys:");
        sb.AppendLine($"Hide: {FormatHotkey(settings.HideHotkeyModifiers, settings.HideHotkeyVirtualKey)}");
        sb.AppendLine($"Restore: {FormatHotkey(settings.RestoreHotkeyModifiers, settings.RestoreHotkeyVirtualKey)}");
        sb.AppendLine("Debug: Ctrl + Shift + Win + D");
        sb.AppendLine();

        // --------------------------------------------------
        // Runtime State
        // --------------------------------------------------
        sb.AppendLine("Runtime:");
        sb.AppendLine($"Has Managed Windows: {windows.Count > 0}");
        sb.AppendLine($"Managed Windows: {windows.Count}");

        foreach (var w in windows)
        {
            sb.AppendLine($"- {w.Title}");
        }

        sb.AppendLine();

        // --------------------------------------------------
        // Notes
        // --------------------------------------------------
        sb.AppendLine("Notes:");
        sb.AppendLine("If a hotkey is not working, it may be reserved or in use by another application.");
        sb.AppendLine();

        sb.AppendLine("=== End Diagnostics ===");

        return sb.ToString();
    }

    // --------------------------------------------------
    // Helpers
    // --------------------------------------------------

    private static string FormatHotkey(
        uint modifiers,
        uint key)
    {
        List<string> parts = new();

        if ((modifiers & 0x0002) != 0)
            parts.Add("Ctrl");

        if ((modifiers & 0x0004) != 0)
            parts.Add("Shift");

        if ((modifiers & 0x0001) != 0)
            parts.Add("Alt");

        if ((modifiers & 0x0008) != 0)
            parts.Add("Win");

        parts.Add(((Keys)key).ToString());

        return string.Join(" + ", parts);
    }

    private static (string edition, string version, string build) GetWindowsInfo()
    {
        try
        {
            using var key = Registry.LocalMachine.OpenSubKey(
                @"SOFTWARE\Microsoft\Windows NT\CurrentVersion");

            string edition = key?.GetValue("ProductName")?.ToString() ?? "Unknown";
            string version = key?.GetValue("DisplayVersion")?.ToString() ?? "Unknown";
            string buildStr = key?.GetValue("CurrentBuild")?.ToString() ?? "0";

            if (int.TryParse(buildStr, out int build))
            {
                if (build >= 22000 && edition.Contains("Windows 10"))
                {
                    edition = edition.Replace("Windows 10", "Windows 11");
                }
            }

            return (edition, version, buildStr);
        }
        catch
        {
            return ("Unknown", "Unknown", "Unknown");
        }
    }
}


