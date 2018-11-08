namespace PracticeProject.WinForm.Printer
{
    partial class PrintDocumentExample
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
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPrintFromTxtFile = new System.Windows.Forms.Button();
            this.brnPrintMultiPageTextFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(112, 110);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPrintFromTxtFile
            // 
            this.btnPrintFromTxtFile.Font = new System.Drawing.Font("宋体", 18F);
            this.btnPrintFromTxtFile.Location = new System.Drawing.Point(32, 153);
            this.btnPrintFromTxtFile.Name = "btnPrintFromTxtFile";
            this.btnPrintFromTxtFile.Size = new System.Drawing.Size(234, 80);
            this.btnPrintFromTxtFile.TabIndex = 1;
            this.btnPrintFromTxtFile.Text = "PrintFromTxtFile";
            this.btnPrintFromTxtFile.UseVisualStyleBackColor = true;
            this.btnPrintFromTxtFile.Click += new System.EventHandler(this.btnPrintFromTxtFile_Click);
            // 
            // brnPrintMultiPageTextFile
            // 
            this.brnPrintMultiPageTextFile.Font = new System.Drawing.Font("宋体", 18F);
            this.brnPrintMultiPageTextFile.Location = new System.Drawing.Point(32, 255);
            this.brnPrintMultiPageTextFile.Name = "brnPrintMultiPageTextFile";
            this.brnPrintMultiPageTextFile.Size = new System.Drawing.Size(234, 80);
            this.brnPrintMultiPageTextFile.TabIndex = 2;
            this.brnPrintMultiPageTextFile.Text = "打印 Windows 窗体中的多页文本文件";
            this.brnPrintMultiPageTextFile.UseVisualStyleBackColor = true;
            this.brnPrintMultiPageTextFile.Click += new System.EventHandler(this.brnPrintMultiPageTextFile_Click);
            // 
            // PrintDocumentExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.brnPrintMultiPageTextFile);
            this.Controls.Add(this.btnPrintFromTxtFile);
            this.Controls.Add(this.btnPrint);
            this.Name = "PrintDocumentExample";
            this.Text = "Printer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnPrintFromTxtFile;
        private System.Windows.Forms.Button brnPrintMultiPageTextFile;
    }
}