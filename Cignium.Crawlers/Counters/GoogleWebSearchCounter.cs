namespace Cignium.Crawlers.Counters
{
    public class GoogleWebSearchCounter : WebSearchCounter
    {
        public GoogleWebSearchCounter(
            HtmlParser parser,
            PageCrawler pageCrawler)
            : base(parser, pageCrawler)
        { }

        protected override string Name { get { return "Google"; } }
        protected override string QueryUrl { get { return "https://www.google.se/search?q={0}"; } }
        protected override string ResultXPath { get { return "//div[@id='resultStats']"; } }
    }
}