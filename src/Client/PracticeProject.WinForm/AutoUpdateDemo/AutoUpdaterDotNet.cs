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
        //string updateUrl = "https://www.baidu.com";

        public AutoUpdaterDotNet()
        {
            InitializeComponent();
            version.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            AutoUpdater.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent;
            AutoUpdater.Start(updateUrl);
        }

        private void checkNewVersion_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateManually_Click(object sender, EventArgs e)
        {

        }



        private void AutoUpdaterOnCheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            if (args != null)
            {
                // 有可用更新
                if (args.IsUpdateAvailable)
                {
                    try
                    {
                        if (AutoUpdater.DownloadUpdate())
                        {
                            Application.Exit();
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, exception.GetType().ToString(), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show(
                        @"未能连接到更新服务器，请检查您的网络连接或稍后重试",
                        @"检查更新失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
