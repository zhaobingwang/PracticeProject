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

        LabelEx labelEx;
        bool _useLabelEx;
        public ButtonEx()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="topText"></param>
        /// <param name="bottomText"></param>
        /// <param name="useLabelEx"></param>
        public ButtonEx(string topText, string bottomText, bool useLabelEx) : this()
        {
            _useLabelEx = useLabelEx;
            lblTop.Text = topText;
            lblBottom.Text = bottomText;
            if (_useLabelEx)
            {
                //lblBottom.Dispose();
                //lblBottom = null;
                this.panelMain.Controls.Remove(lblBottom);
                labelEx = new LabelEx(bottomText);
                labelEx.Height = (int)(percentOfBottom * this.panelMain.Height);
                labelEx.Left = 0;
                labelEx.Top = this.panelMain.Height - labelEx.Height;
                labelEx.Dock = DockStyle.Bottom;
                labelEx.BackColor = Color.FromArgb(255, 255, 255);
                this.panelMain.Controls.Add(labelEx);
            }
        }

        private void ButtonEx_Resize(object sender, EventArgs e)
        {
            if (!_useLabelEx)
            {
                this.panelMain.Width = this.Width;
                this.panelMain.Height = this.Height;
                this.lblTop.Height = (int)(percentOfTop * this.panelMain.Height);
                this.lblBottom.Height = (int)(percentOfBottom * this.panelMain.Height);

                this.panelMain.Dock = DockStyle.Fill;
                this.lblTop.Dock = DockStyle.Top;
                this.lblBottom.Dock = DockStyle.Bottom;
            }
            else
            {
                this.panelMain.Width = this.Width;
                this.panelMain.Height = this.Height;
                this.lblTop.Height = (int)(percentOfTop * this.panelMain.Height);
                labelEx.Height = (int)(percentOfBottom * this.panelMain.Height);


                this.panelMain.Dock = DockStyle.Fill;
                this.lblTop.Dock = DockStyle.Top;
                this.labelEx.Dock = DockStyle.Bottom;
                labelEx.BackColor = Color.FromArgb(255, 255, 255);
            }
        }

        //public void ClearMemory()
        //{
        //    if (labelEx != null)
        //    {
        //        labelEx.Dispose();
        //        labelEx = null;
        //    }
        //    if (lblTop != null)
        //    {
        //        lblTop.Dispose();
        //        lblTop = null;
        //    }
        //    if (lblBottom != null)
        //    {
        //        lblBottom.Dispose();
        //        lblBottom = null;
        //    }
        //}

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams paras = base.CreateParams;
        //        paras.ExStyle |= 0x02000000;
        //        return paras;
        //    }
        //}
    }
}
