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
            var searchPatternFactory = new ExtensionSearchPatternFactory(new[] {"INI"});
            var filesFinder = new LocalFilesFinder(@"X:\Svc\SCOPC-PRODPC\FERME04\PROD\PROD_PC\ini", searchPatternFactory);
            var filesFound = filesFinder.GetFiles();

            foreach (var fileInfo in filesFound)
            {
                Console.WriteLine($"Name: {fileInfo.Name} path: {fileInfo.FullName} ");
            }

            Console.ReadLine();
            Console.WriteLine("Hello World!");
        }
    }
}