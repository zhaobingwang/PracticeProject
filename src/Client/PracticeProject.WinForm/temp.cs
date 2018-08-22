using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

        private void Process_Click(object sender, EventArgs e)
        {
            Task t = new Task(async () =>
            {
                for (int i = 1; i < 101; i++)
                {
                    this.progressBar1.Value = i;
                    await Task.Delay(50);
                }
            });
            t.Start();
        }
    }
}
