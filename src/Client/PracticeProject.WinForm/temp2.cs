﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeProject.WinForm
{
    public partial class temp2 : Form
    {
        public temp2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            temp t = new temp();
            t.ShowDialog();
        }
    }
}
