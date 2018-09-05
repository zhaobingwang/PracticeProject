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
            var html = "https://www.toutiao.com/a6596994489816973838/";
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);
            //var node = htmlDoc.DocumentNode.SelectSingleNode("//div[@class=article-content]");
            //var node = htmlDoc.DocumentNode.SelectSingleNode("//script/BASE_DATA");
            var node = htmlDoc.DocumentNode.SelectSingleNode("//script[contains(text(), 'articleInfo')]");

            Console.WriteLine($"Node Name:{node.Name}\n{node.InnerHtml}");


        }
        
        #endregion
    }
}
