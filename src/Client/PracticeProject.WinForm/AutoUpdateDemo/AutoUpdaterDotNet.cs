using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoUpdaterDotNET;

namespace PracticeProject.WinForm.AutoUpdateDemo
{
    public partial class AutoUpdaterDotNet : Form
    {
        string updateUrl = "http://172.18.34.182:8001/updates/UpdateConfig.xml";
        public AutoUpdaterDotNet()
        {
            InitializeComponent();
            version.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void checkNewVersion_Click(object sender, EventArgs e)
        {
            AutoUpdater.Start(updateUrl);
        }
    }
}
