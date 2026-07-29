using System.Text.Json;
using Microsoft.Win32;
using MiniHide.Models;

namespace MiniHide.Managers;

public sealed class SettingsManager
{
    private const string RunKey =
        @"Software\Microsoft\Windows\CurrentVersion\Run";

    private const string ApplicationName = "MiniHide";

    private static readonly JsonSerializerOptions JsonOptions =
        new()
        {
            WriteIndented = true
        };

    public string SettingsDirectory =>
        Path.Combine(
            Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData),
            "MiniHide");

    public string SettingsFile =>
        Path.Combine(
            SettingsDirectory,
            "settings.json");

    public AppSettings Load()
    {
        try
        {
            if (!File.Exists(SettingsFile))
            {
                AppSettings defaults = new();

                Save(defaults);

                return defaults;
            }

            string json =
                File.ReadAllText(SettingsFile);

            AppSettings settings =
                JsonSerializer.Deserialize<AppSettings>(
                    json,
                    JsonOptions)
                ?? new AppSettings();

            // Migrate older settings files that predate
            // the restore hotkey.

            if (settings.RestoreHotkeyModifiers == 0)
            {
                settings.RestoreHotkeyModifiers = 0x0008;
            }

            if (settings.RestoreHotkeyVirtualKey == 0)
            {
                settings.RestoreHotkeyVirtualKey = 0x24;
            }

            return settings;
        }
        catch
        {
            return new AppSettings();
        }
    }

    public void Save(
        AppSettings settings)
    {
        Directory.CreateDirectory(
            SettingsDirectory);

        string json =
            JsonSerializer.Serialize(
                settings,
                JsonOptions);

        File.WriteAllText(
            SettingsFile,
            json);
    }

    public bool IsStartWithWindowsEnabled()
    {
        using RegistryKey? key =
            Registry.CurrentUser.OpenSubKey(RunKey);

        return key?.GetValue(ApplicationName) is string;
    }

    public void SetStartWithWindows(
        bool enabled)
    {
        using RegistryKey key =
            Registry.CurrentUser.CreateSubKey(RunKey);

        if (enabled)
        {
            key.SetValue(
                ApplicationName,
                $"\"{Application.ExecutablePath}\"");
        }
        else
        {
            key.DeleteValue(
                ApplicationName,
                false);
        }
    }
}


