namespace Cignium.Crawlers.Counters
{
    public interface HtmlParser
    {
        string ParseContentByXPath(string html, string xpath);
    }
}