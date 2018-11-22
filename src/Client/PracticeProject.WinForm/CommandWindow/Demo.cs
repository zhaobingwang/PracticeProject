using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeProject.WinForm.CommandWindow
{
    public partial class Demo : Form
    {
        [DllImport("User32.dll ", EntryPoint = "SetParent")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll ", EntryPoint = "ShowWindow")]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

        public Demo()
        {
            InitializeComponent();

            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe ";
            p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;//加上这句效果更好
            p.Start();
            System.Threading.Thread.Sleep(100);//加上，100如果效果没有就继续加大

            SetParent(p.MainWindowHandle, panel1.Handle); //panel1.Handle为要显示外部程序的容器
            ShowWindow(p.MainWindowHandle, 3);
        }
    }
}
