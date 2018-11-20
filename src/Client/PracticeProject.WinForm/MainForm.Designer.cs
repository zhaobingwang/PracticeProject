namespace PracticeProject.WinForm
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCustomControls = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCustomControls
            // 
            this.btnCustomControls.Location = new System.Drawing.Point(28, 23);
            this.btnCustomControls.Name = "btnCustomControls";
            this.btnCustomControls.Size = new System.Drawing.Size(138, 40);
            this.btnCustomControls.TabIndex = 0;
            this.btnCustomControls.Text = "自定义控件";
            this.btnCustomControls.UseVisualStyleBackColor = true;
            this.btnCustomControls.Click += new System.EventHandler(this.btnCustomControls_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCustomControls);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCustomControls;
    }
}

