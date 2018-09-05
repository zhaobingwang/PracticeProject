using System;
using HtmlAgilityPack;

namespace HtmlAgilityPack_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            FromWeb();
            ParseToutiaoFromWeb();
        }

        #region Parser
        public static void FromWeb()
        {
            var html = "https://www.toutiao.com/";
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);
            var node = htmlDoc.DocumentNode.SelectSingleNode("//head/title");
            Console.WriteLine($"Node Name:{node.Name}\n{node.OuterHtml}");
        }
        public static void ParseToutiaoFromWeb()
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

            //var web2 = new HtmlWeb();
            //var doc2 = web2.LoadFromBrowser(url, html =>
            //{
            //    // WAIT until the dynamic text is set
            //    return !html.Contains("<div class=\"article-content\"></div>");
            //});
            //var t2 = doc2.DocumentNode.SelectSingleNode("//div[@class='article-content']").InnerText;



        }
        
        #endregion
    }
}
