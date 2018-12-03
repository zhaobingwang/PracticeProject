namespace PracticeProject.WinForm
{
    partial class AlertDialog
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
            this.CountDown = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CountDown
            // 
            this.CountDown.AutoSize = true;
            this.CountDown.Location = new System.Drawing.Point(130, 101);
            this.CountDown.Name = "CountDown";
            this.CountDown.Size = new System.Drawing.Size(59, 12);
            this.CountDown.TabIndex = 0;
            this.CountDown.Text = "CountDown";
            // 
            // AlertDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CountDown);
            this.Name = "AlertDialog";
            this.Text = "AllertDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CountDown;
    }
}