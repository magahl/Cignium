using System;

namespace Cignium.Crawlers.Presenters
{
    public class ConsolePrinter : Printer
    {
        public void WriteLine(string input = null)
        {
            Console.WriteLine(input);
        }

        public void Write(string input)
        {
            Console.Write(input);
        }

        public void ReadLine()
        {
            Console.ReadLine();
        }
    }
}