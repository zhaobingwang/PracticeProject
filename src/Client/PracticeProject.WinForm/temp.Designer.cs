namespace PracticeProject.WinForm
{
    partial class temp
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.Process = new System.Windows.Forms.Button();
            this.currentDateTimeLabel1 = new PracticeProject.WinForm.CustomControl.CurrentDateTimeLabel();
            this.test = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Location = new System.Drawing.Point(47, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(680, 177);
            this.panel1.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(110, 66);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(469, 32);
            this.progressBar1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(78, 320);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Process
            // 
            this.Process.Location = new System.Drawing.Point(547, 284);
            this.Process.Name = "Process";
            this.Process.Size = new System.Drawing.Size(75, 23);
            this.Process.TabIndex = 3;
            this.Process.Text = "Process";
            this.Process.UseVisualStyleBackColor = true;
            this.Process.Click += new System.EventHandler(this.Process_Click);
            // 
            // currentDateTimeLabel1
            // 
            this.currentDateTimeLabel1.AutoSize = true;
            this.currentDateTimeLabel1.BackColor = System.Drawing.Color.Transparent;
            this.currentDateTimeLabel1.Font = new System.Drawing.Font("SimSun", 18F);
            this.currentDateTimeLabel1.ForeColor = System.Drawing.Color.White;
            this.currentDateTimeLabel1.Location = new System.Drawing.Point(74, 403);
            this.currentDateTimeLabel1.Name = "currentDateTimeLabel1";
            this.currentDateTimeLabel1.Size = new System.Drawing.Size(286, 24);
            this.currentDateTimeLabel1.TabIndex = 0;
            this.currentDateTimeLabel1.Text = "2018年09月28日 17:31:08";
            // 
            // test
            // 
            this.test.Location = new System.Drawing.Point(375, 375);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(75, 23);
            this.test.TabIndex = 4;
            this.test.Text = "test";
            this.test.UseVisualStyleBackColor = true;
            this.test.Click += new System.EventHandler(this.test_Click);
            // 
            // temp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.test);
            this.Controls.Add(this.Process);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.currentDateTimeLabel1);
            this.Name = "temp";
            this.Text = "temp";
            this.Load += new System.EventHandler(this.temp_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomControl.CurrentDateTimeLabel currentDateTimeLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button Process;
        private System.Windows.Forms.Button test;
    }
}