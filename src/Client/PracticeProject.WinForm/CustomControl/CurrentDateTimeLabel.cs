using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeProject.WinForm.CustomControl
{
    public class CurrentDateTimeLabel : Label
    {
        private Timer timer = null;
        public CurrentDateTimeLabel()
        {
            timer = new Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.Text = $"{DateTime.Now.ToString("yyyy年MM月dd日")} {DateTime.Now.ToLongTimeString()}";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.BackColor = System.Drawing.Color.Transparent;
            this.Font = new System.Drawing.Font("宋体", 18);
            this.ForeColor = System.Drawing.Color.White;
            base.OnPaint(e);
        }
    }
}
