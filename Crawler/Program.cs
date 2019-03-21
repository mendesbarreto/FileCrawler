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
            var searchPatternFactory = new ExtensionSearchPatternFactory(config.Extensions);
            var filesFinder = new LocalFilesFinder(config.RootPath, searchPatternFactory);
            var parser = new CVSParser(config.OutputName);
            var searchPatternMatcher = new SearchPatternMatcher(config.SearchPatterns);

            ICrawler crawler = new Core.FileCrawler(filesFinder, parser, searchPatternMatcher);
            crawler.Craw();
            parser.WriteFile();
            Console.WriteLine("Completed!");
            Console.ReadLine();
        }
    }
}