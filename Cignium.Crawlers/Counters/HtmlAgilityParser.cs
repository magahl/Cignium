using HtmlAgilityPack;

namespace Cignium.Crawlers.Counters
{
    public class HtmlAgilityParser : HtmlParser
    {
        public string ParseContentByXPath(string html, string xpath)
        {
            var contentByXPath = SelectSingleNode(html, xpath);
            if (contentByXPath != null)
            {
                return contentByXPath.InnerText;
            }
            return null;
        }

        private HtmlNode SelectSingleNode(string html, string xpath)
        {
            var htmlDocument = LoadDocument(html);

            return htmlDocument.DocumentNode.SelectSingleNode(xpath);
        }

        private static HtmlDocument LoadDocument(string html)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            return htmlDocument;
        }
    }
}