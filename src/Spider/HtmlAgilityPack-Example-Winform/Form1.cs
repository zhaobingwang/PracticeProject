using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HtmlAgilityPack_Example_Winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string url = "https://www.toutiao.com/a6596994489816973838/";

            //var web1 = new HtmlWeb();
            //var doc1 = web1.LoadFromBrowser(url, o =>
            //{
            //    var webBrowser = (WebBrowser)o;

            //    // WAIT until the dynamic text is set
            //    return !string.IsNullOrEmpty(webBrowser.Document.("uiDynamicText").InnerText);
            //});
            //var t1 = doc1.DocumentNode.SelectSingleNode("//div[@class=article-content]").InnerText;

            var web2 = new HtmlWeb();
            var doc2 = web2.LoadFromBrowser(url, html =>
            {
                // WAIT until the dynamic text is set
                return !html.Contains("<div class=\"article-content\"></div>");
            });
            var t2 = doc2.DocumentNode.SelectSingleNode("//div[@class='article-content']").InnerText;
            richTextBox1.Text = t2;
        }
    }
}
