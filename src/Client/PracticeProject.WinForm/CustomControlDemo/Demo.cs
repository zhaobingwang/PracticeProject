using PracticeProject.WinForm.CustomControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeProject.WinForm.CustomControlDemo
{
    public partial class Demo : Form
    {
        public Demo()
        {
            InitializeComponent();
        }

        private void CustomControlDemo_Load(object sender, EventArgs e)
        {
            //ButtonEx buttonEx = new ButtonEx("08:00-08:30", "第1号", 200, 100);
            ButtonEx buttonEx = new ButtonEx("08:00-08:30", "第1号");
            buttonEx.Width = 200;
            buttonEx.Height = 100;
            buttonEx.Left = 10;
            buttonEx.Top = 10;
            buttonEx.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(buttonEx);

            LabelEx labelEx = new LabelEx("这个是{[重点]}内容");
            labelEx.Left = buttonEx.Left + buttonEx.Width + 100;
            labelEx.Top = 10;
            labelEx.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(labelEx);
        }
    }
}
