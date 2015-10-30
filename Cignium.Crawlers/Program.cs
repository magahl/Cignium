using System.Collections.Generic;
using System.Linq;
using Cignium.Crawlers.Counters;
using Cignium.Crawlers.IoC;
using Cignium.Crawlers.Presenters;

namespace Cignium.Crawlers
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<WebSearchResult> result = GetSearchResult(args);

            Printer printer = Container.ResolvePrinter();
            Presenter presenter = Container.ResolveWebSearchCounterPresenter();

            if (result.Any())
            {
                presenter.Present(result);
                printer.ReadLine();
            }
            else
            {
                printer.WriteLine("No queries matched any of the search engines");    
            }
        }

        private static List<WebSearchResult> GetSearchResult(string[] args)
        {
            var result = new List<WebSearchResult>();

            IList<WebSearchCounter> webSearchCounters = Container.ResolveWebSearchCounters();
            foreach (var term in args)
            {
                foreach (var crawler in webSearchCounters)
                {
                    var item = crawler.GetResult(term);
                    if (item != null)
                    {
                        result.Add(item);
                    }
                }
            }
            return result;
        }
    }
}
