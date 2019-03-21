using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FileCrawler.Core;

namespace FileCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigLoader().Load();
            var searchPatternFactory = new ExtensionSearchPatternFactory(new[] {"INI"});
            var filesFinder = new LocalFilesFinder(config.RootPath, searchPatternFactory);
            var consoleParser = new ConsoleParser();
            ICrawler crawler = new Core.FileCrawler(filesFinder, consoleParser);
            crawler.Craw();
            Console.ReadLine();
            Console.WriteLine("Hello World!");
        }
    }
}