namespace Cignium.Crawlers.Counters
{
    public class YahooWebSearchCounter : WebSearchCounter
    {
        public YahooWebSearchCounter(
            HtmlParser parser,
            PageCrawler pageCrawler)
            : base(parser, pageCrawler)
        { }

        protected override string Name { get { return "Yahoo"; } }
        protected override string QueryUrl { get { return "https://se.search.yahoo.com/search;_ylt=A9m?p={0}"; } }
        protected override string ResultXPath { get { return "//div[@class='compPagination']//span"; } }
    }
}