using System;
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
    public partial class temp : Form
    {
        public temp()
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form t = new temp();
            t.ShowDialog();
            MessageBox.Show(t.GetType().Name);
        }
    }
}
