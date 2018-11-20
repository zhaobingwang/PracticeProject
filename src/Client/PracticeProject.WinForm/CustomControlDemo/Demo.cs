using PracticeProject.WinForm.CustomControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeProject.WinForm.CustomControlDemo
{
    public partial class Demo : Form
    {
        public Demo()
        {
            InitializeComponent();
            this.SetStyle(
    ControlStyles.AllPaintingInWmPaint |
    ControlStyles.UserPaint |
    ControlStyles.OptimizedDoubleBuffer,
    true);
        }

        private void CustomControlDemo_Load(object sender, EventArgs e)
        {
            //ButtonEx buttonEx = new ButtonEx("08:00-08:30", "第1号", 200, 100);
            //ButtonEx buttonEx = new ButtonEx("08:00-08:30", "第{[1]}号", true);
            //buttonEx.Width = 400;
            //buttonEx.Height = 200;
            //buttonEx.Left = 10;
            //buttonEx.Top = 10;
            //this.panelButton.Controls.Add(buttonEx);

            //LabelEx labelEx = new LabelEx("这个是{[重点]}内容");
            //labelEx.Left = buttonEx.Left + buttonEx.Width + 100;
            //labelEx.Top = 10;
            //this.panelButton.Controls.Add(labelEx);


            GenerateButton();
        }


        private int pageIndex = 1;
        private int pageSize = 25;
        private int total = 0;
        private int totalPage = 0;
        private int fakeTotal = 300;

        private int btnWidth = 200;
        private int btnHeight = 100;
        private int btnGap = 30;
        private void GenerateButton()
        {
            panelButton.Controls.Clear();
            var btns = GetButtonList(fakeTotal);

            // 居中算法，计算左，上内边距
            int paddingLeft = (panelButton.Width % (btnWidth + btnGap) + btnGap) / 2;
            int paddingTop = (panelButton.Height % (btnHeight + btnGap) + btnGap) / 2;

            total = btns.Count();
            totalPage = (int)Math.Ceiling((decimal)total / pageSize);
            var beShowButton = btns.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            int x = 0;
            int y = 0;


            foreach (var item in beShowButton)
            {
                ButtonEx btn = new ButtonEx("08:00-08:30", item.Name, true);
                btn.Width = btnWidth;
                btn.Height = btnHeight;
                //btn.Text = item.Name;
                //btn.Name = $"btn_{item.Id}";
                btn.Left = x * (btn.Width + btnGap) + paddingLeft;
                btn.Top = y * (btn.Height + btnGap) + paddingTop;
                btn.Tag = item;

                // 换行
                if (panelButton.Width - btn.Left <= btn.Width)
                {
                    x = 0;
                    y++;
                    btn.Left = x * (btn.Width + btnGap) + paddingLeft;
                    btn.Top = y * (btn.Height + btnGap) + paddingTop;

                    if (panelButton.Height - btn.Top <= btn.Height)
                    {
                        throw new WarningException("按钮设置超出容器范围，部分按钮不可见");
                    }
                }


                btn.Click += Btn_Click;

                panelButton.Controls.Add(btn);
                x++;
            }
        }
        private void Btn_Click(object sender, EventArgs e)
        {

        }

        private List<ButtonGroup> GetButtonList(int count)
        {
            List<ButtonGroup> list = new List<ButtonGroup>();
            for (int i = 1; i < count + 1; i++)
            {
                ButtonGroup button = new ButtonGroup();
                button.Id = i;
                button.Name = "第{[" + i + "]}号";
                list.Add(button);
            }
            return list;
        }
        class ButtonGroup
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            pageIndex--;
            if (pageIndex < 1)
            {
                MessageBox.Show($"当前已经是第一页");
                pageIndex = 1;
                return;
            }

            GenerateButton();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            pageIndex++;
            if (pageIndex > totalPage)
            {
                MessageBox.Show($"当前已经是最后一页");
                pageIndex = totalPage;
                return;
            }
            GenerateButton();
        }

        private void Demo_FormClosing(object sender, FormClosingEventArgs e)
        {
            //foreach (var control in this.panelButton.Controls)
            //{
            //    if (control.GetType().Name == nameof(ButtonEx))
            //    {
            //        var btn = (ButtonEx)control;
            //        btn.ClearMemory();
            //    }
            //}
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams paras = base.CreateParams;
                paras.ExStyle |= 0x02000000;
                return paras;
            }
        }
    }
}
