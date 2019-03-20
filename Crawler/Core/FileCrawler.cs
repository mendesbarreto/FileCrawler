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

        public FileCrawler(IFilesFinder filesFinder, IParser parser)
        {
            _filesFinder = filesFinder;
            _parser = parser;
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
            using (var streamReader = new StreamReader(fileInfo.FullName))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    // TODO: Inject the comparison string by param
                    if (line.Contains("A24130.ISC"))
                    {
                        _parser.parse(fileInfo.Name, line);
                    }
                }
            }
        }
    }
}