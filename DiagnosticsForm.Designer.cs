namespace MiniHide
{
    partial class DiagnosticsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtDiagnostics = new TextBox();
            btnCopy = new Button();
            btnOk = new Button();
            SuspendLayout();
            // 
            // txtDiagnostics
            // 
            txtDiagnostics.BackColor = SystemColors.Window;
            txtDiagnostics.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDiagnostics.ForeColor = SystemColors.ControlText;
            txtDiagnostics.Location = new Point(12, 12);
            txtDiagnostics.Multiline = true;
            txtDiagnostics.Name = "txtDiagnostics";
            txtDiagnostics.ReadOnly = true;
            txtDiagnostics.ScrollBars = ScrollBars.Both;
            txtDiagnostics.Size = new Size(750, 525);
            txtDiagnostics.TabIndex = 0;
            txtDiagnostics.TabStop = false;
            txtDiagnostics.WordWrap = false;
            // 
            // btnCopy
            // 
            btnCopy.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCopy.AutoSize = true;
            btnCopy.Location = new Point(12, 546);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(75, 29);
            btnCopy.TabIndex = 1;
            btnCopy.Text = "Copy";
            btnCopy.UseVisualStyleBackColor = true;
            btnCopy.Click += btnCopy_Click;
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk.AutoSize = true;
            btnOk.Location = new Point(683, 546);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 29);
            btnOk.TabIndex = 2;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // DiagnosticsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            CausesValidation = false;
            ClientSize = new Size(784, 580);
            Controls.Add(btnOk);
            Controls.Add(btnCopy);
            Controls.Add(txtDiagnostics);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(600, 400);
            Name = "DiagnosticsForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MiniHide Diagnostics";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDiagnostics;
        private Button btnCopy;
        private Button btnOk;
    }
}



