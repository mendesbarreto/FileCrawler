using System;
using System.IO;
using System.Linq;
using FileCrawler.Core.Model;

namespace FileCrawler.Core
{
    public interface ICrawler
    {
        void Craw();
    }

    public class FileCrawler: ICrawler
    {
        private readonly IFilesFinder _filesFinder;
        private readonly IParser _parser;
        private readonly IStringMatcher _matcher;

        public FileCrawler(IFilesFinder filesFinder, IParser parser, IStringMatcher matcher)
        {
            _filesFinder = filesFinder;
            _parser = parser;
            _matcher = matcher;
        }

        public void Craw()
        {
            var filesFound = _filesFinder.GetFiles();
            var filesFoundCount = filesFound.ToList().Count;
            int indexCount = 0;
            int processPercent = 0;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"We found: { filesFoundCount } files");
            Console.WriteLine();

            foreach (var fileInfo in _filesFinder.GetFiles())
            {
                indexCount++;
                processPercent = (indexCount * 100) / filesFoundCount;
                Console.Write("\r{0}", $"Parsing file: {indexCount} of: {filesFoundCount} | Progress: {processPercent}%");
                Parse(fileInfo);
            }

            Console.WriteLine();
            Console.ResetColor();
        }

        private void Parse(FileInfo fileInfo)
        {
            string line;
            using (var streamReader = new StreamReader(fileInfo.FullName))
            {
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (_matcher.Match(line))
                    {
                        var result = new CrawlerResult()
                        {
                                FileName = fileInfo.Name,
                                Extension = fileInfo.Extension,
                                MatchContent = line,
                                Path = fileInfo.FullName
                        };

                        _parser.parse(result);
                    }
                }
            }
        }
    }
}