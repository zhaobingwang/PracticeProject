using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeProject.WinForm.layout
{
    public partial class Table : Form
    {
        TableLayoutPanel tableLayoutPanel;
        public Table()
        {
            InitializeComponent();

            //BuildTableOfLabel(2, GetSources(), 0, panel1.Width / 2);
            //BuildTableOfLabel(2, GetSources(), panel1.Width / 2, panel1.Width / 2);
            BuildTableOfButton(2, GetSources(), 0, 450);
        }
        private List<SourceInfos> GetSources()
        {
            List<SourceInfos> sources = new List<SourceInfos>();
            sources.Add(new SourceInfos { Key = "aaa", Value = "11" });
            sources.Add(new SourceInfos { Key = "bbb", Value = "222" });
            sources.Add(new SourceInfos { Key = "cccc", Value = "3" });
            sources.Add(new SourceInfos { Key = "dd", Value = "4" });
            sources.Add(new SourceInfos { Key = "e", Value = "5" });
            return sources;
        }


        private void Table_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// build table of label
        /// </summary>
        /// <param name="group">行</param>
        /// <param name="sources">数据源</param>
        private void BuildTableOfLabel(int groupColumn, List<SourceInfos> sources, int left, int tableWidth)
        {
            int column = groupColumn * 2;
            int row = (int)(Math.Ceiling((decimal)(sources.Count) / groupColumn));
            tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Size = new System.Drawing.Size(tableWidth, panel1.Height);
            tableLayoutPanel.Left = left;
            tableLayoutPanel.ColumnCount = column;
            tableLayoutPanel.RowCount = row;

            for (int iRow = 0; iRow < row; iRow++)
            {
                float height = (float)(Math.Round(100.00 / row, 5));
                tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            }
            for (int iColumn = 0; iColumn < column; iColumn++)
            {
                float width = (float)(Math.Round(100.00 / column, 5));
                tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, width));
            }

            int i = 0;
            int x = 0, y = -1;
            foreach (var source in sources)
            {
                if (i % groupColumn == 0)
                {
                    y++; x = 0; // 换下一行

                }
                else
                {
                    x += 2;
                }

                Label lblKey = new Label();
                lblKey.Text = $"{source.Key}";
                lblKey.Margin = new Padding(3, 0, 3, 0);
                lblKey.Font = new Font("微软雅黑", 18);
                lblKey.AutoSize = true;
                lblKey.Dock = DockStyle.Right;
                lblKey.TextAlign = ContentAlignment.TopRight;
                lblKey.Anchor = AnchorStyles.Right;

                Label lblValue = new Label();
                lblValue.Text = $"{source.Value}";
                lblValue.Margin = new Padding(3, 0, 3, 0);
                lblValue.Font = new Font("微软雅黑", 18);
                lblValue.AutoSize = true;

                tableLayoutPanel.Controls.Add(lblKey, x, y);
                tableLayoutPanel.Controls.Add(lblValue, x + 1, y);

                lblKey.Dock = DockStyle.Left;
                lblKey.Dock = DockStyle.Right;

                i++;
            }
            this.panel1.Controls.Add(tableLayoutPanel);
        }

        /// <summary>
        /// build table of label
        /// </summary>
        /// <param name="group">行</param>
        /// <param name="sources">数据源</param>
        private void BuildTableOfButton(int column, List<SourceInfos> sources, int left, int tableWidth)
        {
            int row = (int)(Math.Ceiling((decimal)(sources.Count) / column));
            tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Size = new System.Drawing.Size(tableWidth, panel1.Height);
            tableLayoutPanel.Left = left;
            tableLayoutPanel.ColumnCount = column;
            tableLayoutPanel.RowCount = row;

            for (int iRow = 0; iRow < row; iRow++)
            {
                float height = (float)(Math.Round(100.00 / row, 5));
                tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            }
            for (int iColumn = 0; iColumn < column; iColumn++)
            {
                float width = (float)(Math.Round(100.00 / column, 5));
                tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, width));
            }

            int i = 0;
            int x = 0, y = -1;
            foreach (var source in sources)
            {
                if (i % column == 0)
                {
                    y++; x = 0; // 换下一行

                }
                else
                {
                    x += 1;
                }

                Button btn = new Button();
                btn.Width = 200;
                btn.Height = 100;
                btn.Text = $"{source.Key}";
                btn.Margin = new Padding(3, 0, 3, 0);
                btn.Font = new Font("微软雅黑", 18);
                btn.Dock = DockStyle.Right;
                btn.TextAlign = ContentAlignment.MiddleCenter;
                //btn.Anchor = AnchorStyles.Right;

                tableLayoutPanel.Controls.Add(btn, x, y);

                //btn.Dock = DockStyle.Left;

                i++;
            }
            this.panel1.Controls.Add(tableLayoutPanel);
        }
    }
    public class SourceInfos
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
