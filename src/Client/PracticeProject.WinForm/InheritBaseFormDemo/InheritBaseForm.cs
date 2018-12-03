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
    /// <summary>
    /// winform窗体继承测试
    /// </summary>
    public partial class InheritBaseForm : BaseForm
    {
        public InheritBaseForm()
        {
            InitializeComponent();
        }

        private void InheritBaseForm_Load(object sender, EventArgs e)
        {

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            AlertDialog alert = new AlertDialog();
            alert.ShowDialog();
            alert.Dispose();
        }
    }
}
