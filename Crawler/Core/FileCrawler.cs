using System;
using System.IO;
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
            foreach (var fileInfo in _filesFinder.GetFiles())
            {
                Parse(fileInfo);
            }
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