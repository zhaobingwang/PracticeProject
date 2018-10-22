namespace PracticeProject.WinForm.AutoUpdateDemo
{
    partial class AutoUpdaterDotNet
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
            this.checkNewVersion = new System.Windows.Forms.Button();
            this.version = new System.Windows.Forms.Label();
            this.btnUpdateManually = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkNewVersion
            // 
            this.checkNewVersion.Location = new System.Drawing.Point(145, 187);
            this.checkNewVersion.Name = "checkNewVersion";
            this.checkNewVersion.Size = new System.Drawing.Size(75, 23);
            this.checkNewVersion.TabIndex = 0;
            this.checkNewVersion.Text = "更新";
            this.checkNewVersion.UseVisualStyleBackColor = true;
            this.checkNewVersion.Click += new System.EventHandler(this.checkNewVersion_Click);
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.Location = new System.Drawing.Point(167, 359);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(47, 12);
            this.version.TabIndex = 1;
            this.version.Text = "version";
            // 
            // btnUpdateManually
            // 
            this.btnUpdateManually.Location = new System.Drawing.Point(363, 214);
            this.btnUpdateManually.Name = "btnUpdateManually";
            this.btnUpdateManually.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateManually.TabIndex = 2;
            this.btnUpdateManually.Text = "手动更新";
            this.btnUpdateManually.UseVisualStyleBackColor = true;
            this.btnUpdateManually.Click += new System.EventHandler(this.btnUpdateManually_Click);
            // 
            // AutoUpdaterDotNet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnUpdateManually);
            this.Controls.Add(this.version);
            this.Controls.Add(this.checkNewVersion);
            this.Name = "AutoUpdaterDotNet";
            this.Text = "AutoUpdaterDotNet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button checkNewVersion;
        private System.Windows.Forms.Label version;
        private System.Windows.Forms.Button btnUpdateManually;
    }
}