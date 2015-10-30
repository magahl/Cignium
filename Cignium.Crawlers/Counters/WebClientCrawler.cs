using System.Net;

namespace Cignium.Crawlers.Counters
{
    public class WebClientCrawler : PageCrawler
    {
        public string Crawl(string url)
        {
            return new WebClient().DownloadString(url);
        }
    }
}