using System;

namespace FileCrawler.Core
{
    public class ConsoleParser: IParser
    {
        public void parse(string fileName, string lineContent)
        {
            Console.WriteLine($"File: {fileName}, Line: {lineContent}");
        }
    }
}