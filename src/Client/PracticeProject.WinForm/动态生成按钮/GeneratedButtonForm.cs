using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace PracticeProject.WinForm
{
    /// <summary>
    /// 动态生成button窗体
    /// </summary>
    public partial class GeneratedButtonForm : Form
    {
        public GeneratedButtonForm()
        {
            InitializeComponent();
        }
        private static int pageIndex = 1;
        private static int pageSize = 31;
        private static int total = 0;
        private static int totalPage = 0;
        private static int fakeTotal = 63;

        private static int btnWidth = 100;
        private static int btnHeight = 100;
        private static int btnGap = 10;
        private void GeneratedButtonForm_Load(object sender, EventArgs e)
        {
            GenerateButton();
        }


        private void GenerateButton()
        {
            panelButton.Controls.Clear();
            var btns = GetButtonList(fakeTotal);

            // 居中算法，计算左，上内边距
            int paddingLeft = (panelButton.Width % (btnWidth + btnGap) + btnGap) / 2;
            int paddingTop = (panelButton.Height % (btnHeight + btnGap) + btnGap) / 2;

            total = fakeTotal;
            totalPage = (int)Math.Ceiling((decimal)total / pageSize);
            var beShowButton = btns.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            int i = 0;
            int j = 0;


            foreach (var item in beShowButton)
            {
                //btnWidth = global::PracticeProject.WinForm.Properties.Resources.m_btn_bk_01.Width;
                //btnHeight = global::PracticeProject.WinForm.Properties.Resources.m_btn_bk_01.Height;
                Button btn = new Button();
                btn.Width = btnWidth;
                btn.Height = btnHeight;
                btn.Text = item.Name;
                btn.Left = i * (btn.Width + btnGap) + paddingLeft;
                btn.Top = j * (btn.Height + btnGap) + paddingTop;

                //btn.BackgroundImage = global::PracticeProject.WinForm.Properties.Resources.m_btn_bk_01;
                //btn.BackgroundImageLayout = ImageLayout.Tile;
                //btn.Width = btn.BackgroundImage.Width;
                //btn.Height = btn.BackgroundImage.Height;
                //btn.FlatAppearance.BorderSize = 0;
                //btn.FlatStyle = FlatStyle.Flat;
                //btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
                //btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
                //btn.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);

                if (panelButton.Width - btn.Left <= btn.Width)
                {
                    i = 0;
                    j++;
                    btn.Left = i * (btn.Width + btnGap) + paddingLeft;
                    btn.Top = j * (btn.Height + btnGap) + paddingTop;

                    if (panelButton.Height - btn.Top <= btn.Height)
                    {
                        throw new WarningException("按钮设置超出容器范围，部分按钮不可见");
                    }
                }


                btn.Click += Btn_Click;

                panelButton.Controls.Add(btn);
                i++;
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            MessageBox.Show(button.Text);
        }

        private List<ButtonGroup> GetButtonList(int count)
        {
            List<ButtonGroup> list = new List<ButtonGroup>();
            for (int i = 1; i < count + 1; i++)
            {
                ButtonGroup button = new ButtonGroup();
                button.Id = i;
                button.Name = $"按钮{i}";
                list.Add(button);
            }
            return list;
        }
        class ButtonGroup
        {
            public int Id { get; set; }
            public string Name { get; set; }
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
    }
}
