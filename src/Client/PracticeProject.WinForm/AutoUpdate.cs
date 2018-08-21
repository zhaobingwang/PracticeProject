using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeProject.WinForm
{
    public partial class AutoUpdate : Form
    {
        public AutoUpdate()
        {
            InitializeComponent();


            InstallUpdateSyncWithInfo();

            // 获取当前部署

            ApplicationDeployment appd = ApplicationDeployment.CurrentDeployment;

            // 取得版本号

            label1.Text = appd.CurrentVersion.ToString();
        }

        private void InstallUpdateSyncWithInfo()
        {
            UpdateCheckInfo info = null;
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

                try
                {
                    info = ad.CheckForDetailedUpdate();
                    
                }
                catch (DeploymentDownloadException dde)
                {
                    MessageBox.Show("The new version of the application cannot be downloaded at this time. \n\nPlease check your network connection, or try again later. Error: " + dde.Message);
                    return;
                }
                catch (InvalidDeploymentException ide)
                {
                    MessageBox.Show("Cannot check for a new version of the application. The ClickOnce deployment is corrupt. Please redeploy the application and try again. Error: " + ide.Message);
                    return;
                }
                catch (InvalidOperationException ioe)
                {
                    MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " + ioe.Message);
                    return;
                }
                if (info.UpdateAvailable)
                {
                    Boolean doUpdate = true;
                    if (!info.IsUpdateRequired)
                    {
                        DialogResult dr = MessageBox.Show("是否更新应用程序", "有可用的更新", MessageBoxButtons.OKCancel);
                        if (!(DialogResult.OK == dr))
                        {
                            doUpdate = false;
                        }
                    }
                    else
                    {
                        // Display a message that the app MUST reboot. Display the minimum required version.
                        MessageBox.Show("当前应用必须升级后才能使用，应用将升级到：" +
                            "version to version " + info.MinimumRequiredVersion.ToString() +
                            "。应用程序将在安装更新后重启。",
                            "有可用的更新", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    if (doUpdate)
                    {
                        try
                        {
                            ad.Update();
                            MessageBox.Show("正在更新中，将在之后重启应用程序。");
                            Application.Restart();
                            this.Close();
                        }
                        catch (DeploymentDownloadException dde)
                        {
                            MessageBox.Show("安装最新程序出错 \n\n请检查网络连接或者稍后重试。错误: " + dde);
                            return;
                        }
                    }
                }
            }
        }
    }
}
