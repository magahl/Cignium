using System.Collections.Generic;
using Cignium.Crawlers.Counters;
using Cignium.Crawlers.Presenters;

namespace Cignium.Crawlers.IoC
{
    /// <summary>
    /// Poor mans IoC-container
    /// </summary>
    public class Container
    {
        public static IList<WebSearchCounter> ResolveWebSearchCounters()
        {
            var htmlAgilityParser = new HtmlAgilityParser();
            var webClientCrawler = new WebClientCrawler();

            return new List<WebSearchCounter>()
            {
                new GoogleWebSearchCounter(htmlAgilityParser, webClientCrawler),
                new BingWebSearchCounter(htmlAgilityParser, webClientCrawler),
                new YahooWebSearchCounter(htmlAgilityParser, webClientCrawler)
            };
        }

        public static Printer ResolvePrinter()
        {
            return new ConsolePrinter();
        }

        public static Presenter ResolveWebSearchCounterPresenter()
        {
            return new WebSearchCounterPresenter(ResolvePrinter());
        }
    }
}