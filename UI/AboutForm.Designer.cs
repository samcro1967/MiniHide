namespace MiniHide
{
    partial class AboutForm
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
            pictureBoxIcon = new PictureBox();
            lblProduct = new Label();
            lblVersion = new Label();
            lblCopyright = new Label();
            btnOk = new Button();
            txtDescription = new TextBox();
            lnkLicense = new LinkLabel();
            lnkGitHub = new LinkLabel();
            lnkSettingsFolder = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxIcon
            // 
            pictureBoxIcon.Location = new Point(20, 21);
            pictureBoxIcon.Name = "pictureBoxIcon";
            pictureBoxIcon.Size = new Size(48, 51);
            pictureBoxIcon.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBoxIcon.TabIndex = 0;
            pictureBoxIcon.TabStop = false;
            // 
            // lblProduct
            // 
            lblProduct.AutoSize = true;
            lblProduct.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProduct.Location = new Point(98, 21);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(105, 32);
            lblProduct.TabIndex = 1;
            lblProduct.Text = "Product";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(98, 62);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(86, 20);
            lblVersion.TabIndex = 2;
            lblVersion.Text = "Version text";
            // 
            // lblCopyright
            // 
            lblCopyright.AutoSize = true;
            lblCopyright.Location = new Point(98, 101);
            lblCopyright.Name = "lblCopyright";
            lblCopyright.Size = new Size(74, 20);
            lblCopyright.TabIndex = 3;
            lblCopyright.Text = "Copyright";
            // 
            // btnOk
            // 
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(98, 405);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 24);
            btnOk.TabIndex = 5;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // txtDescription
            // 
            txtDescription.BorderStyle = BorderStyle.None;
            txtDescription.Location = new Point(98, 142);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ReadOnly = true;
            txtDescription.Size = new Size(300, 149);
            txtDescription.TabIndex = 6;
            txtDescription.TabStop = false;
            txtDescription.Text = "Description";
            // 
            // lnkLicense
            // 
            lnkLicense.AutoSize = true;
            lnkLicense.LinkBehavior = LinkBehavior.HoverUnderline;
            lnkLicense.Location = new Point(98, 367);
            lnkLicense.Name = "lnkLicense";
            lnkLicense.Size = new Size(122, 20);
            lnkLicense.TabIndex = 8;
            lnkLicense.TabStop = true;
            lnkLicense.Text = "View MIT License";
            lnkLicense.LinkClicked += lnkLicense_LinkClicked;
            // 
            // lnkGitHub
            // 
            lnkGitHub.AutoSize = true;
            lnkGitHub.LinkBehavior = LinkBehavior.HoverUnderline;
            lnkGitHub.Location = new Point(98, 294);
            lnkGitHub.Name = "lnkGitHub";
            lnkGitHub.Size = new Size(127, 20);
            lnkGitHub.TabIndex = 9;
            lnkGitHub.TabStop = true;
            lnkGitHub.Text = "Project on GitHub";
            lnkGitHub.LinkClicked += lnkGitHub_LinkClicked;
            // 
            // lnkSettingsFolder
            // 
            lnkSettingsFolder.AutoSize = true;
            lnkSettingsFolder.LinkBehavior = LinkBehavior.HoverUnderline;
            lnkSettingsFolder.Location = new Point(98, 329);
            lnkSettingsFolder.Name = "lnkSettingsFolder";
            lnkSettingsFolder.Size = new Size(148, 20);
            lnkSettingsFolder.TabIndex = 10;
            lnkSettingsFolder.TabStop = true;
            lnkSettingsFolder.Text = "Open App Folder";
            lnkSettingsFolder.LinkClicked += lnkSettingsFolder_LinkClicked;
            // 
            // AboutForm
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(462, 453);
            Controls.Add(lnkSettingsFolder);
            Controls.Add(lnkGitHub);
            Controls.Add(lnkLicense);
            Controls.Add(txtDescription);
            Controls.Add(btnOk);
            Controls.Add(lblCopyright);
            Controls.Add(lblVersion);
            Controls.Add(lblProduct);
            Controls.Add(pictureBoxIcon);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "About MiniHide";
            Load += AboutForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxIcon;
        private Label lblProduct;
        private Label lblVersion;
        private Label lblCopyright;
        private Button btnOk;
        private TextBox txtDescription;
        private LinkLabel lnkLicense;
        private LinkLabel lnkGitHub;
        private LinkLabel lnkSettingsFolder;
    }
}



