using System.Reflection;
using MiniHide.Models;

namespace MiniHide.Managers;

public sealed class TrayManager : IDisposable
{
    private NotifyIcon? trayIcon;

    private bool startupNotificationShown;

    private readonly ContextMenuStrip menu;

    private readonly Icon icon;

    private readonly Image aboutImage;
    private readonly Image restoreImage;
    private readonly Image settingsImage;
    private readonly Image exitImage;

    public event EventHandler? AboutRequested;
    public event EventHandler? RestoreAllRequested;
    public event EventHandler<ManagedWindowEventArgs>? ManagedWindowRestoreRequested;
    public event EventHandler? SettingsRequested;
    public event EventHandler? ExitRequested;

    public TrayManager(Icon icon)
    {
        this.icon = icon;

        menu = new ContextMenuStrip();

        aboutImage =
            LoadIcon("about.ico");

        restoreImage =
            LoadIcon("restore.ico");

        settingsImage =
            LoadIcon("settings.ico");

        exitImage =
            LoadIcon("exit.ico");

        CreateNotifyIcon();

        RebuildMenu([]);
    }

    private static Bitmap LoadIcon(
        string fileName)
    {
        Assembly assembly =
            Assembly.GetExecutingAssembly();

        string resourceName =
            $"{assembly.GetName().Name}.Resources.{fileName}";

        using Stream stream =
            assembly.GetManifestResourceStream(resourceName)
            ?? throw new InvalidOperationException(
                $"Embedded resource '{resourceName}' was not found.");

        using Icon icon =
            new(stream);

        return icon.ToBitmap();
    }

    private void CreateNotifyIcon()
    {
        trayIcon = new NotifyIcon
        {
            Icon = icon,
            Text = "MiniHide",
            Visible = true,
            ContextMenuStrip = menu
        };

        trayIcon.DoubleClick += (_, _) =>
        {
            AboutRequested?.Invoke(
                this,
                EventArgs.Empty);
        };
    }

    public void Recreate()
    {
        trayIcon?.Dispose();

        CreateNotifyIcon();
    }

    public void ShowStartupNotification(
        string hideWindowHotkey,
        string restoreAllWindowsHotkey)
    {
        if (startupNotificationShown ||
            trayIcon is null)
        {
            return;
        }

        string message =
            string.Join(
                Environment.NewLine,
                [
                    $"Hide: {hideWindowHotkey}",
                    $"Restore All: {restoreAllWindowsHotkey}"
                ]);

        trayIcon.ShowBalloonTip(
            5000,
            "MiniHide is running",
            message,
            ToolTipIcon.Info);

        startupNotificationShown = true;
    }

    public void UpdateManagedWindows(
        IReadOnlyCollection<ManagedWindow> windows)
    {
        RebuildMenu(windows);
    }

    private void RebuildMenu(
        IReadOnlyCollection<ManagedWindow> windows)
    {
        menu.Items.Clear();

        ToolStripMenuItem about =
            new("About MiniHide")
            {
                Image = aboutImage
            };

        about.Click += (_, _) =>
        {
            AboutRequested?.Invoke(
                this,
                EventArgs.Empty);
        };

        menu.Items.Add(about);

        menu.Items.Add(new ToolStripSeparator());

        ToolStripMenuItem restoreAll =
            new("Restore All")
            {
                Image = restoreImage,
                Enabled = windows.Count > 0
            };

        restoreAll.Click += (_, _) =>
        {
            RestoreAllRequested?.Invoke(
                this,
                EventArgs.Empty);
        };

        menu.Items.Add(restoreAll);

        if (windows.Count == 0)
        {
            menu.Items.Add(
                new ToolStripMenuItem("(No hidden windows)")
                {
                    Enabled = false
                });
        }
        else
        {
            foreach (ManagedWindow window in windows.OrderBy(w => w.Title))
            {
                ToolStripMenuItem item =
                    new(window.Title)
                    {
                        Image = window.Icon
                    };

                item.Click += (_, _) =>
                {
                    ManagedWindowRestoreRequested?.Invoke(
                        this,
                        new ManagedWindowEventArgs(window));
                };

                menu.Items.Add(item);
            }
        }

        menu.Items.Add(new ToolStripSeparator());

        ToolStripMenuItem settings =
            new("Settings")
            {
                Image = settingsImage
            };

        settings.Click += (_, _) =>
        {
            SettingsRequested?.Invoke(
                this,
                EventArgs.Empty);
        };

        menu.Items.Add(settings);

        menu.Items.Add(new ToolStripSeparator());

        ToolStripMenuItem exit =
            new("Exit")
            {
                Image = exitImage
            };

        exit.Click += (_, _) =>
        {
            ExitRequested?.Invoke(
                this,
                EventArgs.Empty);
        };

        menu.Items.Add(exit);
    }

    public void Dispose()
    {
        trayIcon?.Dispose();

        aboutImage.Dispose();
        restoreImage.Dispose();
        settingsImage.Dispose();
        exitImage.Dispose();

        menu.Dispose();
    }
}


