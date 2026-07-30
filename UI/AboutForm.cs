/*
 * File: AboutForm.cs
 * Path: /AboutForm.cs
 *
 * Purpose:
 * Display application information for MiniHide.
 */

using System.Diagnostics;
using System.Reflection;

namespace MiniHide;

public partial class AboutForm : Form
{
    public AboutForm(Icon? appIcon)
    {
        InitializeComponent();

        Icon = appIcon;

        if (Icon != null)
        {
            pictureBoxIcon.Image = Icon.ToBitmap();
        }

        Text = "About MiniHide";

        lblProduct.Text = Application.ProductName;

        Version? version =
            Assembly.GetExecutingAssembly().GetName().Version;

        lblVersion.Text = $"Version {version}";

        lblCopyright.Text = "© 2026 samcro1967";

        txtDescription.Text =
            "Hide and restore application windows from the system tray using a configurable global hotkey." +
            "\r\n\r\n" +
            "Debug" +
            "\r\n" +
            "Press Ctrl + Shift + Win + D to open diagnostics.";
    }

    private void lnkLicense_LinkClicked(
        object sender,
        LinkLabelLinkClickedEventArgs e)
    {
        Process.Start(
            new ProcessStartInfo
            {
                FileName = "https://github.com/samcro1967/MiniHide/blob/main/LICENSE",
                UseShellExecute = true
            });
    }

    private void lnkGitHub_LinkClicked(
        object sender,
        LinkLabelLinkClickedEventArgs e)
    {
        Process.Start(
            new ProcessStartInfo
            {
                FileName = "https://github.com/samcro1967/MiniHide",
                UseShellExecute = true
            });
    }

    private void lnkSettingsFolder_LinkClicked(
        object sender,
        LinkLabelLinkClickedEventArgs e)
    {
        string folder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "MiniHide");

        Directory.CreateDirectory(folder);

        Process.Start(
            new ProcessStartInfo
            {
                FileName = folder,
                UseShellExecute = true
            });
    }

    private void AboutForm_Load(object sender, EventArgs e)
    {

    }

    private void btnOk_Click(object sender, EventArgs e)
    {

    }
}



