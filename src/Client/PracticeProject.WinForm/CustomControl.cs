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
    public partial class CustomControl : Form
    {
        public CustomControl()
        {
            InitializeComponent();
        }

        private void CustomControl_Load(object sender, EventArgs e)
        {
            button1.BackgroundImage = global::PracticeProject.WinForm.Properties.Resources.button;
            button1.BackgroundImageLayout = ImageLayout.Tile;
            button1.Width = button1.BackgroundImage.Width;
            button1.Height = button1.BackgroundImage.Height;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(DateTime.Now.ToString());
        }
    }
}
