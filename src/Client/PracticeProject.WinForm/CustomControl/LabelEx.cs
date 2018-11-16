using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeProject.WinForm.CustomControl
{
    public partial class LabelEx : UserControl
    {
        public LabelEx()
        {

        }
        public LabelEx(string text, Font fontPrimary = null, Font fontMinor = null, int gapX = -5) : this()
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new Exception("param is null.");
            }
            if (text.IndexOf('[') < 0 || text.IndexOf(']') < 0 || text.IndexOf('{') < 0 || text.IndexOf('}') < 0)
            {
                throw new Exception("not supported value.");
            }
            InitializeComponent();
            // format:这个是{[重点]}内容"
            string[] str = text.Split(new char[2] { '{', '}' });
            int left = 0;
            int top = 0;
            if (fontPrimary == null)
                fontPrimary = new Font("黑体", 20, FontStyle.Bold);
            if (fontMinor == null)
                fontMinor = new Font("黑体", 14);

            int gapY = (int)(fontPrimary.GetHeight() - fontMinor.GetHeight());
            int totalWidth = 0;
            int maxHeight = fontPrimary.Height;

            this.Height = maxHeight;
            foreach (var item in str)
            {
                Label lbl = new Label();
                lbl.Padding = new Padding(0);
                lbl.Margin = new Padding(0);
                lbl.AutoSize = true;
                lbl.Padding = new Padding(0, 0, 0, 0);
                if (item.IndexOf('[') >= 0)
                {
                    lbl.Font = fontPrimary;
                    lbl.Text = item.Substring(1, item.Length - 2);
                    top = (this.Height - lbl.Height - gapY) / 2;
                }
                else
                {
                    lbl.Font = fontMinor;
                    lbl.Text = item;
                    top = (this.Height - lbl.Height) / 2;
                }

                lbl.Left = left;
                lbl.Top = top;
                this.Controls.Add(lbl);

                left += lbl.Width + gapX;
                totalWidth += lbl.Width;
            }
            this.Width = totalWidth;
        }

        private void LabelEx_Resize(object sender, EventArgs e)
        {

        }
    }
}
