namespace Cignium.Crawlers.Presenters
{
    public interface Printer
    {
        void WriteLine(string input = null);
        void Write(string input);
        void ReadLine();
    }
}