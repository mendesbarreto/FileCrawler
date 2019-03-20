﻿using System;
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
            var searchPatternFactory = new ExtensionSearchPatternFactory(new[] {"INI"});
            var filesFinder = new LocalFilesFinder(@"X:\Svc\SCOPC-PRODPC\FERME04\PROD\PROD_PC\ini", searchPatternFactory);
            var consoleParser = new ConsoleParser();
            ICrawler crawler = new Core.FileCrawler(filesFinder, consoleParser);
            crawler.Craw();
            Console.ReadLine();
            Console.WriteLine("Hello World!");
        }
    }
}