using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FileCrawler.Core;
using FileCrawler.Core.Feature.StringCleaner;

namespace FileCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigLoader().Load();
            var searchPatternFactory = new FileNameAndExtensionSearchPatternFactory(config.FileNamePattern);
            var filesFinder = new LocalFilesFinder(config.RootPath, searchPatternFactory);
            var parser = new CVSParser(config.OutputName, new StringIniCleaner());
            var searchPatternMatcher = new SCFileSearchPatternMatcher(config.SearchPatterns);

            ICrawler crawler = new Core.FileCrawler(filesFinder, parser, searchPatternMatcher);

            crawler.Craw();
            parser.WriteFile();

            Console.WriteLine("Completed!");

            Console.ReadLine();
        }
    }
}