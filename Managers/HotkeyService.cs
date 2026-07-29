using MiniHide.Helpers;
using MiniHide.Models;

namespace MiniHide.Managers;

public sealed class HotkeyService : IDisposable
{
    private readonly IntPtr windowHandle;

    private HotkeyManager? hideHotkeyManager;

    private HotkeyManager? restoreHotkeyManager;

    private HotkeySettings? currentSettings;

    private HotkeyManager? debugHotkeyManager;

    public HotkeyService(
        IntPtr windowHandle)
    {
        this.windowHandle = windowHandle;
    }

    public void Register(
        HotkeySettings settings)
    {
        RegisterManagers(settings);

        currentSettings = settings;
    }

    public bool Update(
        HotkeySettings settings,
        out string? error)
    {
        error = null;

        if (!HotkeyValidator.Validate(
                settings.HideModifiers,
                settings.HideVirtualKey,
                settings.RestoreModifiers,
                settings.RestoreVirtualKey,
                out error))
        {
            return false;
        }

        HotkeySettings? previousSettings =
            currentSettings;

        try
        {
            RegisterManagers(settings);

            currentSettings = settings;

            return true;
        }
        catch (Exception ex)
        {
            error = ex.Message;

            if (previousSettings is not null)
            {
                try
                {
                    RegisterManagers(previousSettings);

                    currentSettings = previousSettings;
                }
                catch
                {
                    Dispose();
                }
            }

            return false;
        }
    }

    public static bool IsHideHotkey(
        Message message)
    {
        return message.WParam.ToInt32() ==
            HotkeyIds.Hide;
    }

    public static bool IsRestoreHotkey(
        Message message)
    {
        return message.WParam.ToInt32() ==
            HotkeyIds.Restore;
    }

    private void RegisterManagers(
    HotkeySettings settings)
    {
        Dispose();

        hideHotkeyManager =
            new HotkeyManager(
                windowHandle,
                HotkeyIds.Hide,
                settings.HideModifiers,
                settings.HideVirtualKey);

        restoreHotkeyManager =
            new HotkeyManager(
                windowHandle,
                HotkeyIds.Restore,
                settings.RestoreModifiers,
                settings.RestoreVirtualKey);

        debugHotkeyManager =
            new HotkeyManager(
                windowHandle,
                HotkeyIds.Debug,
                0x0002 | 0x0004 | 0x0008, // Ctrl + Shift + Win
                0x44); // D

        // Register in order with proper rollback
        hideHotkeyManager!.Register();

        try
        {
            restoreHotkeyManager!.Register();

            try
            {
                debugHotkeyManager!.Register();
            }
            catch
            {
                restoreHotkeyManager!.Dispose();
                hideHotkeyManager!.Dispose();

                restoreHotkeyManager = null;
                hideHotkeyManager = null;
                debugHotkeyManager = null;

                throw;
            }
        }
        catch
        {
            hideHotkeyManager!.Dispose();

            hideHotkeyManager = null;
            restoreHotkeyManager = null;

            throw;
        }
    }

    public static bool IsDebugHotkey(Message message)
    {
        return message.WParam.ToInt32() ==
            HotkeyIds.Debug;
    }

    public void Dispose()
    {
        hideHotkeyManager?.Dispose();

        restoreHotkeyManager?.Dispose();

        debugHotkeyManager?.Dispose();

        hideHotkeyManager = null;

        restoreHotkeyManager = null;

        debugHotkeyManager = null;
    }
}


