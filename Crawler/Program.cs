using System;
using System.Collections.Generic;
using System.IO;
using FileCrawler.Core;

namespace FileCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            var searchPatternFactory = new SearchPatternFactory(new[] {"INIT"});
            var directoryExists = Directory.Exists("X:/Svc");
            var directoryExists2 = Directory.Exists(@"X:\Svc");
            var filesFinder = new FilesFinder(@"X:\Svc\SCOPC-PRODPC\FERME04\PROD\PROD_PC\ini", searchPatternFactory);

            Console.Write(filesFinder.GetFiles());
            Console.ReadLine();
            Console.WriteLine("Hello World!");
        }
    }
}