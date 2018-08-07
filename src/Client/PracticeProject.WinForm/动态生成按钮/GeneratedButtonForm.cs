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
        private static int pageSize = 30;
        private static int total = 0;
        private static int totalPage = 0;
        private static int fakeTotal = 63;
        private void GeneratedButtonForm_Load(object sender, EventArgs e)
        {
            GeneratedButton();
        }


        private void GeneratedButton()
        {
            panelButton.Controls.Clear();
            var btns = GetButtonList(fakeTotal);
            total = fakeTotal;
            totalPage = (int)Math.Ceiling((decimal)total / pageSize);
            var beShowButton = btns.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            int i = 0;
            int j = 0;
            foreach (var item in beShowButton)
            {
                Button btn = new Button();
                btn.Width = 100;
                btn.Height = 40;
                btn.Text = item.Name;
                btn.Left = i * (btn.Width + 10);
                btn.Top = j * (btn.Height + 10);

                if (panelButton.Width - btn.Right <= btn.Width)
                {
                    i = 0;
                    j++;
                    btn.Left = i * (btn.Width + 10);
                    btn.Top = j * (btn.Height + 10);
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
            GeneratedButton();
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

            GeneratedButton();
        }
    }
}
