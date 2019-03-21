using System;
using System.IO;

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
                Read(fileInfo);
            }
        }

        private void Read(FileInfo fileInfo)
        {
            string line;
            using (var streamReader = new StreamReader(fileInfo.FullName))
            {
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (_matcher.Match(line))
                    {
                        _parser.parse(fileInfo.Name, line);
                    }
                }
            }
        }
    }
}