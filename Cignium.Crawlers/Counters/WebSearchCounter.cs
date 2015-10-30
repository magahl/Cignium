using System.Text.RegularExpressions;
using System.Web;

namespace Cignium.Crawlers.Counters
{
    public abstract class WebSearchCounter
    {
        private readonly HtmlParser htmlParser;
        private readonly PageCrawler crawler;

        protected WebSearchCounter(
            HtmlParser htmlParser, 
            PageCrawler crawler)
        {
            this.htmlParser = htmlParser;
            this.crawler = crawler;
        }

        protected abstract string Name { get; }
        protected abstract string QueryUrl { get; }
        protected abstract string ResultXPath { get; }

        public WebSearchResult GetResult(string term)
        {
            var html = GetPageHtml(term);
            var content = htmlParser.ParseContentByXPath(html, ResultXPath);

            if (!string.IsNullOrEmpty(content))
            {
                return new WebSearchResult
                {
                    Score = GetScore(content),
                    Crawler = Name,
                    Term = term
                };
            }

            return null;
        }

        private static int GetScore(string content)
        {
            return int.Parse(Regex.Replace(HttpUtility.HtmlDecode(content), @"\D", ""));
        }

        private string GetPageHtml(string term)
        {
            return crawler.Crawl(string.Format(QueryUrl, HttpUtility.UrlEncode(term)));
        }
    }
}
