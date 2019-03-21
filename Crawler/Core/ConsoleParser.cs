using System;
using FileCrawler.Core.Model;

namespace FileCrawler.Core
{
    public class ConsoleParser: IParser
    {
        public void parse(CrawlerResult result)
        {
            Console.WriteLine($"File: {result.FileName}, " +
                              $"Content: {result.MatchContent} " +
                              $"Extension: {result.Extension} " +
                              $"Path: {result.Path}");
        }
    }
}