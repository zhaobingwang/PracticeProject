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
        private Font _fontPrimary;
        private Font _fontMinor;
        private int _gapX;
        string[] str;
        public LabelEx()
        {
            InitializeComponent();
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
            // format:这个是{[重点]}内容"
            str = text.Split(new char[2] { '{', '}' });

            if (fontPrimary == null)
                _fontPrimary = new Font("黑体", 20, FontStyle.Bold);
            if (fontMinor == null)
                _fontMinor = new Font("黑体", 14);
        }

        private void LabelEx_Resize(object sender, EventArgs e)
        {
        }

        private void LabelEx_Load(object sender, EventArgs e)
        {
            int left = 0;
            int top = 0;
            int gapY = (int)(_fontPrimary.GetHeight() - _fontMinor.GetHeight());
            int totalWidth = 0;
            int maxHeight = this.Height;

            this.Height = maxHeight;
            panel1.Width = 0;
            foreach (var item in str)
            {
                Label lbl = new Label();
                lbl.Padding = new Padding(0);
                lbl.Margin = new Padding(0);
                lbl.AutoSize = true;
                lbl.Padding = new Padding(0, 0, 0, 0);
                if (item.IndexOf('[') >= 0)
                {
                    lbl.Font = _fontPrimary;
                    lbl.Text = item.Substring(1, item.Length - 2);
                    top = (this.Height - lbl.Height - gapY) / 2;
                }
                else
                {
                    lbl.Font = _fontMinor;
                    lbl.Text = item;
                    top = (this.Height - lbl.Height) / 2;
                }

                lbl.Left = left;
                lbl.Top = top;
                this.panel1.Controls.Add(lbl);
                panel1.Width += lbl.Width;
                left += lbl.Width + _gapX;
                totalWidth += lbl.Width;
            }
            //this.Width = totalWidth;
            panel1.Height = maxHeight;
            panel1.Left = (this.Width - panel1.Width) / 2;
            panel1.Top = (this.Height - panel1.Height) / 2;
        }
    }
}
