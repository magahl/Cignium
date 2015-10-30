using System.Collections.Generic;
using System.Linq;
using Cignium.Crawlers.Counters;

namespace Cignium.Crawlers.Presenters
{
    public interface Presenter
    {
        void Present(List<WebSearchResult> results);
    }

    public class WebSearchCounterPresenter : Presenter
    {
        private readonly Printer _printer;

        public WebSearchCounterPresenter(Printer printer)
        {
            _printer = printer;
        }

        public void Present(List<WebSearchResult> results)
        {
            PrintByTerm(results);
            var byCrawler = results.GroupBy(x => x.Crawler);
            PrintByCrawler(byCrawler);
            PrintTotalWinner(byCrawler);
        }

        private void PrintByTerm(List<WebSearchResult> results)
        {
            var byTerm = results.GroupBy(x => x.Term);
            foreach (var term in byTerm)
            {
                _printer.Write(string.Format("{0}: ", term.Key));
                foreach (var result in term)
                {
                    _printer.Write(string.Format("{0}: {1} ", result.Crawler,result.Score));
                }
                _printer.WriteLine();
            }
            _printer.WriteLine();
        }

        private void PrintByCrawler(IEnumerable<IGrouping<string, WebSearchResult>> byCrawler)
        {
            foreach (var crawler in byCrawler)
            {
                _printer.WriteLine(string.Format("{0} winner: {1}", crawler.Key, crawler.OrderByDescending(x => x.Score).First().Term));
            }
        }

        private void PrintTotalWinner(IEnumerable<IGrouping<string, WebSearchResult>> byCrawler)
        {
            var orderedEnumerable = byCrawler.OrderByDescending(x => x.Sum(y => y.Score)).First();
            _printer.WriteLine("Total winner: " + orderedEnumerable.Key);
        }
    }
}