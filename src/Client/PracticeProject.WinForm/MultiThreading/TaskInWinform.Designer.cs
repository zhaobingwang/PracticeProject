namespace PracticeProject.WinForm.MultiThreading
{
    partial class TaskInWinform
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
            this.lblMessage = new System.Windows.Forms.Label();
            this.loading = new System.Windows.Forms.PictureBox();
            this.lblCountDown = new System.Windows.Forms.Label();
            this.btnRunTask = new System.Windows.Forms.Button();
            this.lblRunTaskMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.loading)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(321, 35);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(65, 12);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "lblMessage";
            // 
            // loading
            // 
            this.loading.Image = global::PracticeProject.WinForm.Properties.Resources.loading_01;
            this.loading.Location = new System.Drawing.Point(86, 11);
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(38, 36);
            this.loading.TabIndex = 1;
            this.loading.TabStop = false;
            // 
            // lblCountDown
            // 
            this.lblCountDown.AutoSize = true;
            this.lblCountDown.Location = new System.Drawing.Point(652, 35);
            this.lblCountDown.Name = "lblCountDown";
            this.lblCountDown.Size = new System.Drawing.Size(77, 12);
            this.lblCountDown.TabIndex = 2;
            this.lblCountDown.Text = "lblCountDown";
            // 
            // btnRunTask
            // 
            this.btnRunTask.Location = new System.Drawing.Point(72, 311);
            this.btnRunTask.Name = "btnRunTask";
            this.btnRunTask.Size = new System.Drawing.Size(75, 23);
            this.btnRunTask.TabIndex = 3;
            this.btnRunTask.Text = "btnRunTask";
            this.btnRunTask.UseVisualStyleBackColor = true;
            this.btnRunTask.Click += new System.EventHandler(this.btnRunTask_Click);
            // 
            // lblRunTaskMessage
            // 
            this.lblRunTaskMessage.AutoSize = true;
            this.lblRunTaskMessage.Location = new System.Drawing.Point(217, 316);
            this.lblRunTaskMessage.Name = "lblRunTaskMessage";
            this.lblRunTaskMessage.Size = new System.Drawing.Size(107, 12);
            this.lblRunTaskMessage.TabIndex = 4;
            this.lblRunTaskMessage.Text = "lblRunTaskMessage";
            // 
            // TaskInWinform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblRunTaskMessage);
            this.Controls.Add(this.btnRunTask);
            this.Controls.Add(this.lblCountDown);
            this.Controls.Add(this.loading);
            this.Controls.Add(this.lblMessage);
            this.Name = "TaskInWinform";
            this.Text = "TaskInWinform";
            this.Load += new System.EventHandler(this.TaskInWinform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.loading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.PictureBox loading;
        private System.Windows.Forms.Label lblCountDown;
        private System.Windows.Forms.Button btnRunTask;
        private System.Windows.Forms.Label lblRunTaskMessage;
    }
}