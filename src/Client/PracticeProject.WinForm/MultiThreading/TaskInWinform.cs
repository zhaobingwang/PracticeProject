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
using WinformTimer = System.Windows.Forms.Timer;

namespace PracticeProject.WinForm.MultiThreading
{
    public partial class TaskInWinform : Form
    {
        private int countDown = 60;
        private WinformTimer timer;
        public TaskInWinform()
        {
            InitializeComponent();
            lblCountDown.Text = $"{countDown.ToString()} s";

            timer = new WinformTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = 1000;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lblCountDown.Text = $"{(--countDown).ToString()} s";
        }

        private void TaskInWinform_Load(object sender, EventArgs e)
        {
            Task task = Task.Factory.StartNew(() =>
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    lblMessage.Text = "start";
                }));
                DoSomething();
                BeginInvoke(new MethodInvoker(() =>
                {
                    lblMessage.Text = "finish";
                }));

            });
        }

        private void DoSomething()
        {
            Thread.Sleep(3000);
        }

        private async void btnRunTask_Click(object sender, EventArgs e)
        {
            btnRunTask.Enabled = false;

            lblRunTaskMessage.Text = "start";
            await Task.Delay(3000);

            lblRunTaskMessage.Text = "end";
            btnRunTask.Enabled = true;
        }
    }
}
