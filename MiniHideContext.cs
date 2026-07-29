using Microsoft.Win32;
using MiniHide.Helpers;
using MiniHide.Managers;
using MiniHide.Models;

namespace MiniHide;

public sealed class MiniHideContext : ApplicationContext
{
    private readonly TrayManager trayManager;
    private readonly WindowManager windowManager = new();
    private readonly SettingsManager settingsManager = new();

    private readonly AppSettings settings;

    private readonly HotkeyWindow hotkeyWindow;
    private readonly HotkeyService hotkeyService;

    private readonly Icon appIcon;

    private DiagnosticsForm? diagnosticsForm;

    public MiniHideContext()
    {
        settings = settingsManager.Load();

        // ✅ FIX: Use EXE icon directly (no file, no resource lookup)
        appIcon = Icon.ExtractAssociatedIcon(Application.ExecutablePath)!;

        trayManager = new TrayManager(appIcon);

        hotkeyWindow = new HotkeyWindow();

        // ✅ Force handle creation
        var handle = hotkeyWindow.Handle;

        hotkeyService = new HotkeyService(handle);

        hotkeyWindow.HotkeyPressed += OnHotkeyPressed;

        trayManager.AboutRequested += (_, _) => OpenAbout();
        trayManager.RestoreAllRequested += (_, _) => RestoreAllWindows();
        trayManager.ManagedWindowRestoreRequested += (_, e) => RestoreManagedWindow(e.Window);
        trayManager.SettingsRequested += (_, _) => OpenSettings();
        trayManager.ExitRequested += (_, _) => Exit();

        Application.Idle += OnFirstIdle;
    }

    private async void OnFirstIdle(object? sender, EventArgs e)
    {
        Application.Idle -= OnFirstIdle;

        // ✅ FIX: Do NOT crash if hotkey fails
        try
        {
            hotkeyService.Register(settings.Hotkeys);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                ex.Message,
                "MiniHide Hotkey Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        // Apply startup setting
        ApplyStartupSetting(settings.StartWithWindows);

        await Task.Delay(500);

        if (settings.StartMinimized)
        {
            ShowStartupNotification();
        }
        else
        {
            OpenSettings();
        }
    }

    private void OnHotkeyPressed(Message m)
    {
        if (HotkeyService.IsHideHotkey(m))
            HideActiveWindow();
        else if (HotkeyService.IsRestoreHotkey(m))
            RestoreAllWindows();
        else if (HotkeyService.IsDebugHotkey(m))
            ShowDiagnostics();
    }

    private void ShowStartupNotification()
    {
        string hideHotkey = FormatHotkey(
            settings.HideHotkeyModifiers,
            settings.HideHotkeyVirtualKey);

        string restoreHotkey = FormatHotkey(
            settings.RestoreHotkeyModifiers,
            settings.RestoreHotkeyVirtualKey);

        trayManager.Recreate();

        trayManager.ShowStartupNotification(
            hideHotkey,
            restoreHotkey);
    }

    private void HideActiveWindow()
    {
        ManagedWindow? window = windowManager.GetActiveWindow();

        if (window == null ||
            !windowManager.CanManageWindow(window) ||
            windowManager.IsManaged(window.Handle) ||
            !windowManager.HideWindow(window))
            return;

        windowManager.AddManagedWindow(window);

        trayManager.UpdateManagedWindows(
            windowManager.ManagedWindows);
    }

    private void RestoreAllWindows()
    {
        windowManager.RestoreAllWindows();

        trayManager.UpdateManagedWindows(
            windowManager.ManagedWindows);
    }

    private void RestoreManagedWindow(ManagedWindow window)
    {
        windowManager.RestoreWindow(window);

        windowManager.RemoveManagedWindow(window.Handle);

        trayManager.UpdateManagedWindows(
            windowManager.ManagedWindows);
    }

    private void OpenSettings()
    {
        using SettingsForm dialog = new(settings, appIcon);

        if (dialog.ShowDialog() != DialogResult.OK)
            return;

        var updated = dialog.Settings;

        if (!hotkeyService.Update(updated.Hotkeys, out var error))
        {
            MessageBox.Show(
                error,
                "MiniHide Hotkey Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        settingsManager.Save(updated);

        ApplyStartupSetting(updated.StartWithWindows);

        settings.StartWithWindows = updated.StartWithWindows;
        settings.StartMinimized = updated.StartMinimized;
        settings.HideHotkeyModifiers = updated.HideHotkeyModifiers;
        settings.HideHotkeyVirtualKey = updated.HideHotkeyVirtualKey;
        settings.RestoreHotkeyModifiers = updated.RestoreHotkeyModifiers;
        settings.RestoreHotkeyVirtualKey = updated.RestoreHotkeyVirtualKey;
    }

    private void OpenAbout()
    {
        using AboutForm dialog = new(appIcon);
        dialog.ShowDialog();
    }

    private void ShowDiagnostics()
    {
        if (diagnosticsForm is not null && !diagnosticsForm.IsDisposed)
        {
            diagnosticsForm.WindowState = FormWindowState.Normal;
            diagnosticsForm.BringToFront();
            diagnosticsForm.Activate();
            return;
        }

        string diagnostics =
            DiagnosticsBuilder.Build(
                settings,
                windowManager.ManagedWindows);

        diagnosticsForm = new DiagnosticsForm(diagnostics);

        diagnosticsForm.StartPosition = FormStartPosition.CenterScreen;
        diagnosticsForm.TopMost = true;

        diagnosticsForm.Shown += (_, _) =>
        {
            diagnosticsForm.TopMost = false;
            diagnosticsForm.Activate();
        };

        diagnosticsForm.FormClosed += (_, _) =>
        {
            diagnosticsForm = null;
        };

        diagnosticsForm.Show();
    }

    private void Exit()
    {
        windowManager.RestoreAllWindows();

        hotkeyService.Dispose();
        hotkeyWindow.Dispose();
        trayManager.Dispose();
        appIcon.Dispose();

        ExitThread();
    }

    private void ApplyStartupSetting(bool enable)
    {
        const string correctName = "MiniHide";

        using RegistryKey key = Registry.CurrentUser.OpenSubKey(
            @"Software\Microsoft\Windows\CurrentVersion\Run",
            true)!;

        foreach (var valueName in key.GetValueNames())
        {
            var value = key.GetValue(valueName)?.ToString();

            if (
                valueName.Contains("MiniHide", StringComparison.OrdinalIgnoreCase) ||
                (value != null && value.Contains("MiniHide", StringComparison.OrdinalIgnoreCase))
            )
            {
                key.DeleteValue(valueName, false);
            }
        }

        if (enable)
        {
            key.SetValue(correctName, $"\"{Application.ExecutablePath}\"");
        }
    }

    private static string FormatHotkey(uint modifiers, uint key)
    {
        List<string> parts = [];

        if ((modifiers & 0x0002) != 0) parts.Add("Ctrl");
        if ((modifiers & 0x0004) != 0) parts.Add("Shift");
        if ((modifiers & 0x0001) != 0) parts.Add("Alt");
        if ((modifiers & 0x0008) != 0) parts.Add("Win");

        parts.Add(((Keys)key).ToString());

        return string.Join(" + ", parts);
    }
}