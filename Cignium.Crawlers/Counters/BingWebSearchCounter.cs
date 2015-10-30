namespace Cignium.Crawlers.Counters
{
    public class BingWebSearchCounter : WebSearchCounter
    {
        public BingWebSearchCounter(
            HtmlParser parser, 
            PageCrawler pageCrawler) 
            : base(parser, pageCrawler)
        {}

        protected override string Name {get{ return "Bing"; }} 
        protected override string QueryUrl {get { return "http://www.bing.com/search?q={0}";}}
        protected override string ResultXPath { get { return "//span[@class='sb_count']"; } } 
    }
}