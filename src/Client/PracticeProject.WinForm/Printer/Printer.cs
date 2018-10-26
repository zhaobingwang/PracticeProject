using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeProject.WinForm.Printer
{
    public partial class Printer : Form
    {
        public Printer()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();

            printDocument.DocumentName = "测试打印文档名";
            PaperSize ps = new PaperSize("页名称", 100, 70);
            ps.RawKind = 150;   //如果是自定义纸张，就要大于118，（A4值为9，详细纸张类型与值的对照请看https://docs.microsoft.com/zh-cn/dotnet/api/system.drawing.printing.papersize.rawkind?redirectedfrom=MSDN&view=netframework-4.7.2#System_Drawing_Printing_PaperSize_RawKind
            printDocument.DefaultPageSettings.PaperSize = ps;

            // 打印开始前
            printDocument.BeginPrint += new PrintEventHandler(printDocument_BeginPrint);

            // 打印输出（过程）
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);

            // 打印结束
            printDocument.EndPrint += new PrintEventHandler(printDocument_EndPrint);

            // 跳出打印对话框，提供打印参数可视化设置，如选择哪个打印机打印此文档等
            PrintDialog pd = new PrintDialog();
            pd.Document = printDocument;
            if (DialogResult.OK == pd.ShowDialog())    // 如果确认，将会覆盖所有的打印参数设置
            {
                //页面设置对话框（可以不使用，其实PrintDialog对话框已提供页面设置）
                PageSetupDialog psd = new PageSetupDialog();
                psd.Document = printDocument;
                if (DialogResult.OK == psd.ShowDialog())
                {
                    //打印预览
                    PrintPreviewDialog ppd = new PrintPreviewDialog();
                    ppd.Document = printDocument;
                    if (DialogResult.OK == ppd.ShowDialog())
                        printDocument.Print(); //打印
                }
            }
        }



        private void printDocument_EndPrint(object sender, PrintEventArgs e)
        {
            // 打印结束后相关操作
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // 打印内容在此处写入
            Graphics g = e.Graphics;
            Brush b = new SolidBrush(Color.Black);
            Font titleFont = new Font("宋体", 16);
            string title = "火箭出四个首轮签报价巴特勒 全梭哈只为总冠军";
            g.DrawString(title, titleFont, b, new PointF((e.PageBounds.Width - g.MeasureString(title, titleFont).Width) / 2, 20));
            g.DrawString(title, titleFont, b, new PointF((e.PageBounds.Width - g.MeasureString(title, titleFont).Width) / 2, 50));
            g.DrawString(title, titleFont, b, new PointF((e.PageBounds.Width - g.MeasureString(title, titleFont).Width) / 2, 80));

            string content = GetPrintContent();

            g.DrawString(content, titleFont, b, new PointF((e.PageBounds.Width - g.MeasureString(content, titleFont).Width) / 2, 110));

            // e.Cancel // 获取或设置是否取消打印
            // e.HasMorePages // 为true时，该函数执行完毕后还会重新执行一遍（可用于动态分页）
        }

        private void printDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            // 也可以把一些打印的参数放在此处设置
        }

        private string GetPrintContent()
        {
            string content = "网易体育10月26日报道：\n据著名NBA记者沃纳罗斯基报道，联盟消息人士透露，休斯敦火箭队正在重新报价明尼苏达森林狼明星球员吉米 - 巴特勒。据了解，火箭队最近开出的报价中包含了未来的四个首轮选秀权。\n今年夏天，巴特勒向森林狼管理层提出了交易申请。此后，包括迈阿密热火、休斯敦火箭以及费城76人等多支球队都对巴特勒发起了追求。其中热火队曾经一度非常接近于得到巴特勒。然而，由于森林狼要价过高，交易还是最终告吹。森林狼老板格伦-泰勒和巴特勒紧急会面，双方最终达成了和解。消息人士称，在巴特勒继续为森林狼打球的同时，从常规赛开始至今森林狼也继续在寻求着巴特勒的交易。\n火箭队的做法也代表了牺牲未来全力以赴争取当下的一种态度。他们希望能够这个赛季就得到一个全明星球员加盟，从而与詹姆斯-哈登、保罗一起冲击总冠军。\n火箭队的报价已经开出了最大的筹码，他们所提供的四个首轮选秀权达到了一笔交易中允许使用涉及首轮选秀权数量的上限。同时，联盟也有规定，一支球队在七年之内只能交易四个首轮签，而且不能送出连续两年的首轮签。同时，在这个提议中，首轮签也不能够有顺位保护。\n消息人士称，森林狼和火箭谈判中所涉及到的球员仍然没有确定。\n目前为止，森林狼对于巴特勒的报价没有动摇。巴特勒已经明确表态，如果不被交易他将会在明年夏天离开球队。火箭队有意得到巴特勒，并且还希望可以在明年夏天与他完成续约。巴特勒现年29岁，明年夏天他将会成为不受限制自由球员。据了解，森林狼老板向巴特勒保证，只要巴特勒本人对于其他球队的报价感到满意，他们就会选择交易。\n森林狼篮球运营总裁锡伯杜和老板泰勒的理念有所不同。锡伯杜希望森林狼能够继续保持竞争力，所以他对选秀权的渴望没有泰勒那么大。\n本赛季前4场比赛，巴特勒场均贡献24.8分5.3个篮板3.5次助攻。";
            return content;
        }
    }
}
