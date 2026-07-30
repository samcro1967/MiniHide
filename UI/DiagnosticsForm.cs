using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiniHide
{
    public partial class DiagnosticsForm : Form
    {
        public DiagnosticsForm(string diagnostics)
        {
            InitializeComponent();

            // Populate text
            txtDiagnostics.Text = diagnostics;

            // TextBox behavior
            txtDiagnostics.Multiline = true;
            txtDiagnostics.ReadOnly = true;
            txtDiagnostics.ScrollBars = ScrollBars.Both;
            txtDiagnostics.WordWrap = false;
            txtDiagnostics.Font = new Font("Consolas", 9);

            // UX polish
            txtDiagnostics.SelectAll();
            btnCopy.Text = "Copy";

            // Default buttons
            AcceptButton = btnOk;
            CancelButton = btnOk;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtDiagnostics.Text);
            btnCopy.Text = "Copied!";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}



