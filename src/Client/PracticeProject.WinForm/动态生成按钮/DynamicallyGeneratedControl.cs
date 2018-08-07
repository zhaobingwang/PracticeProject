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
    public partial class DynamicallyGeneratedControl : Form
    {
        public DynamicallyGeneratedControl()
        {
            InitializeComponent();
        }

        private void btnGeneratedButton_Click(object sender, EventArgs e)
        {
            GeneratedButtonForm form = new GeneratedButtonForm();
            form.Show();
        }
    }
}
