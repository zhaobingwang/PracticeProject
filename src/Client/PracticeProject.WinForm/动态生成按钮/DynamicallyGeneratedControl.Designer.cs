namespace PracticeProject.WinForm
{
    partial class DynamicallyGeneratedControl
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
            this.btnGeneratedButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGeneratedButton
            // 
            this.btnGeneratedButton.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGeneratedButton.Location = new System.Drawing.Point(12, 12);
            this.btnGeneratedButton.Name = "btnGeneratedButton";
            this.btnGeneratedButton.Size = new System.Drawing.Size(201, 71);
            this.btnGeneratedButton.TabIndex = 0;
            this.btnGeneratedButton.Text = "动态生成按钮";
            this.btnGeneratedButton.UseVisualStyleBackColor = true;
            this.btnGeneratedButton.Click += new System.EventHandler(this.btnGeneratedButton_Click);
            // 
            // DynamicallyGeneratedControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGeneratedButton);
            this.Name = "DynamicallyGeneratedControl";
            this.Text = "DynamicallyGeneratedControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGeneratedButton;
    }
}