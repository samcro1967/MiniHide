using MiniHide.Helpers;
using MiniHide.Models;

namespace MiniHide;

public partial class SettingsForm : Form
{
    private readonly AppSettings settings;

    public SettingsForm(
        AppSettings settings,
        Icon? appIcon)
    {
        InitializeComponent();

        Icon = appIcon;

        this.settings = settings;

        chkStartWithWindows.Checked =
            settings.StartWithWindows;

        chkStartMinimized.Checked =
            settings.StartMinimized;

        cmbModifier.DataSource =
            HotkeyDefinitions.Modifiers.ToList();

        cmbKey.DataSource =
            HotkeyDefinitions.SupportedKeys.ToList();

        cmbRestoreModifier.DataSource =
            HotkeyDefinitions.Modifiers.ToList();

        cmbRestoreKey.DataSource =
            HotkeyDefinitions.SupportedKeys.ToList();

        cmbModifier.SelectedItem =
            HotkeyDefinitions.Modifiers.FirstOrDefault(
                m => m.Value == settings.HideHotkeyModifiers)
            ?? HotkeyDefinitions.Modifiers.First();

        cmbKey.SelectedItem =
            HotkeyDefinitions.SupportedKeys.FirstOrDefault(
                k => k.Value == settings.HideHotkeyVirtualKey)
            ?? HotkeyDefinitions.SupportedKeys.First();

        cmbRestoreModifier.SelectedItem =
            HotkeyDefinitions.Modifiers.FirstOrDefault(
                m => m.Value == settings.RestoreHotkeyModifiers)
            ?? HotkeyDefinitions.Modifiers.First();

        cmbRestoreKey.SelectedItem =
            HotkeyDefinitions.SupportedKeys.FirstOrDefault(
                k => k.Value == settings.RestoreHotkeyVirtualKey)
            ?? HotkeyDefinitions.SupportedKeys.First();
    }

    public AppSettings Settings => new()
    {
        StartWithWindows =
            chkStartWithWindows.Checked,

        StartMinimized =
            chkStartMinimized.Checked,

        HideHotkeyModifiers =
            ((HotkeyItem)cmbModifier.SelectedItem!).Value,

        HideHotkeyVirtualKey =
            ((HotkeyItem)cmbKey.SelectedItem!).Value,

        RestoreHotkeyModifiers =
            ((HotkeyItem)cmbRestoreModifier.SelectedItem!).Value,

        RestoreHotkeyVirtualKey =
            ((HotkeyItem)cmbRestoreKey.SelectedItem!).Value,

        ConfirmBeforeHiding =
            settings.ConfirmBeforeHiding,

        ExcludedProcesses =
            settings.ExcludedProcesses
    };

    private void btnOk_Click(
        object sender,
        EventArgs e)
    {
        DialogResult = DialogResult.OK;
    }

    private void btnCancel_Click(
        object sender,
        EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
    }

    private void groupBox1_Enter(
        object sender,
        EventArgs e)
    {
    }

    private void cmbRestoreModifier_SelectedIndexChanged(
        object sender,
        EventArgs e)
    {
    }

    private void cmbRestoreKey_SelectedIndexChanged(
        object sender,
        EventArgs e)
    {
    }
}



