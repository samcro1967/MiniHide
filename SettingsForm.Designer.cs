namespace MiniHide
{
    partial class SettingsForm
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
            grpGeneral = new GroupBox();
            chkStartMinimized = new CheckBox();
            chkStartWithWindows = new CheckBox();
            btnCancel = new Button();
            btnOk = new Button();
            groupBox1 = new GroupBox();
            lblKey = new Label();
            cmbKey = new ComboBox();
            lblModifier = new Label();
            cmbModifier = new ComboBox();
            groupBox3 = new GroupBox();
            label5 = new Label();
            cmbRestoreKey = new ComboBox();
            label6 = new Label();
            cmbRestoreModifier = new ComboBox();
            grpGeneral.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // grpGeneral
            // 
            grpGeneral.Controls.Add(chkStartMinimized);
            grpGeneral.Controls.Add(chkStartWithWindows);
            grpGeneral.Location = new Point(12, 13);
            grpGeneral.Name = "grpGeneral";
            grpGeneral.Size = new Size(283, 107);
            grpGeneral.TabIndex = 0;
            grpGeneral.TabStop = false;
            grpGeneral.Text = "General";
            // 
            // chkStartMinimized
            // 
            chkStartMinimized.AutoSize = true;
            chkStartMinimized.Location = new Point(15, 58);
            chkStartMinimized.Name = "chkStartMinimized";
            chkStartMinimized.Size = new Size(136, 24);
            chkStartMinimized.TabIndex = 1;
            chkStartMinimized.Text = "Start minimized";
            chkStartMinimized.UseVisualStyleBackColor = true;
            // 
            // chkStartWithWindows
            // 
            chkStartWithWindows.AutoSize = true;
            chkStartWithWindows.Location = new Point(15, 27);
            chkStartWithWindows.Name = "chkStartWithWindows";
            chkStartWithWindows.Size = new Size(159, 24);
            chkStartWithWindows.TabIndex = 0;
            chkStartWithWindows.Text = "Start with Windows";
            chkStartWithWindows.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(220, 548);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 24);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(13, 548);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 24);
            btnOk.TabIndex = 2;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblKey);
            groupBox1.Controls.Add(cmbKey);
            groupBox1.Controls.Add(lblModifier);
            groupBox1.Controls.Add(cmbModifier);
            groupBox1.Location = new Point(12, 139);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(283, 177);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Hide Window Hotkey";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // lblKey
            // 
            lblKey.AutoSize = true;
            lblKey.Location = new Point(17, 92);
            lblKey.Name = "lblKey";
            lblKey.Size = new Size(33, 20);
            lblKey.TabIndex = 3;
            lblKey.Text = "Key";
            // 
            // cmbKey
            // 
            cmbKey.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKey.FormattingEnabled = true;
            cmbKey.Location = new Point(15, 115);
            cmbKey.Name = "cmbKey";
            cmbKey.Size = new Size(262, 28);
            cmbKey.TabIndex = 2;
            // 
            // lblModifier
            // 
            lblModifier.AutoSize = true;
            lblModifier.Location = new Point(17, 23);
            lblModifier.Name = "lblModifier";
            lblModifier.Size = new Size(66, 20);
            lblModifier.TabIndex = 1;
            lblModifier.Text = "Modifier";
            // 
            // cmbModifier
            // 
            cmbModifier.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModifier.FormattingEnabled = true;
            cmbModifier.Location = new Point(17, 46);
            cmbModifier.Name = "cmbModifier";
            cmbModifier.Size = new Size(260, 28);
            cmbModifier.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(cmbRestoreKey);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(cmbRestoreModifier);
            groupBox3.Location = new Point(13, 322);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(282, 177);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "Restore All Hotkey";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 92);
            label5.Name = "label5";
            label5.Size = new Size(33, 20);
            label5.TabIndex = 3;
            label5.Text = "Key";
            // 
            // cmbRestoreKey
            // 
            cmbRestoreKey.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRestoreKey.FormattingEnabled = true;
            cmbRestoreKey.Location = new Point(15, 115);
            cmbRestoreKey.Name = "cmbRestoreKey";
            cmbRestoreKey.Size = new Size(261, 28);
            cmbRestoreKey.TabIndex = 2;
            cmbRestoreKey.SelectedIndexChanged += cmbRestoreKey_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 23);
            label6.Name = "label6";
            label6.Size = new Size(66, 20);
            label6.TabIndex = 1;
            label6.Text = "Modifier";
            // 
            // cmbRestoreModifier
            // 
            cmbRestoreModifier.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRestoreModifier.FormattingEnabled = true;
            cmbRestoreModifier.Location = new Point(17, 46);
            cmbRestoreModifier.Name = "cmbRestoreModifier";
            cmbRestoreModifier.Size = new Size(259, 28);
            cmbRestoreModifier.TabIndex = 0;
            cmbRestoreModifier.SelectedIndexChanged += cmbRestoreModifier_SelectedIndexChanged;
            // 
            // SettingsForm
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(307, 583);
            Controls.Add(groupBox3);
            Controls.Add(btnCancel);
            Controls.Add(groupBox1);
            Controls.Add(btnOk);
            Controls.Add(grpGeneral);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            RightToLeftLayout = true;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MiniHide Settings";
            grpGeneral.ResumeLayout(false);
            grpGeneral.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpGeneral;
        private CheckBox chkStartMinimized;
        private CheckBox chkStartWithWindows;
        private Button btnCancel;
        private Button btnOk;

        private GroupBox groupBox1;
        private Label lblModifier;
        private ComboBox cmbModifier;
        private Label lblKey;
        private ComboBox cmbKey;
        private GroupBox groupBox3;
        private Label label5;
        private ComboBox cmbRestoreKey;
        private Label label6;
        private ComboBox cmbRestoreModifier;
    }
}



