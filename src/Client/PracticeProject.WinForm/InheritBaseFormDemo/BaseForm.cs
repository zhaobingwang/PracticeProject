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
    public class BaseForm : Form
    {
        public BaseForm()
        {
        }

        private Timer timerCountDown;
        public void CountDown(Label label, int second)
        {
            timerCountDown = new Timer();
            timerCountDown.Interval = 1000;
            timerCountDown.Enabled = true;
            timerCountDown.Tick += TimerCountDown_Tick;
        }

        private void TimerCountDown_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Test()
        {
            MessageBox.Show("hi.");
        }
    }
}
