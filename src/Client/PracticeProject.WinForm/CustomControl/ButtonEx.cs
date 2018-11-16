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
    public partial class ButtonEx : UserControl
    {
        private double percentOfTop = 0.4;
        private double percentOfBottom = 0.6;
        public ButtonEx()
        {
            InitializeComponent();
        }
        public ButtonEx(string topText, string bottomText) : this()
        {
            lblTop.Text = topText;
            lblBottom.Text = bottomText;
        }
        //public ButtonEx(string topText, string bottomText, int width, int height)
        //{
        //    InitializeComponent();

        //    lblTop.Text = topText;
        //    lblBottom.Text = bottomText;

        //    this.panel1.BorderStyle = BorderStyle.FixedSingle;
        //    this.panel1.Width = width;
        //    this.panel1.Height = height;
        //    this.lblTop.Height = (int)(percentOfTop * this.panel1.Height);
        //    this.lblBottom.Height = (int)(percentOfBottom * this.panel1.Height);

        //    this.panel1.Dock = DockStyle.Fill;
        //    this.lblTop.Dock = DockStyle.Top;
        //    this.lblBottom.Dock = DockStyle.Bottom;
        //}

        private void ButtonEx_Resize(object sender, EventArgs e)
        {
            this.panelMain.Width = this.Width;
            this.panelMain.Height = this.Height;
            this.lblTop.Height = (int)(percentOfTop * this.panelMain.Height);
            this.lblBottom.Height = (int)(percentOfBottom * this.panelMain.Height);

            this.panelMain.Dock = DockStyle.Fill;
            this.lblTop.Dock = DockStyle.Top;
            this.lblBottom.Dock = DockStyle.Bottom;
        }
    }
}
