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

        public FileCrawler(IFilesFinder filesFinder)
        {
            _filesFinder = filesFinder;
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
                        Console.WriteLine($"{fileInfo.Name}: {line}");
                    }
                }
            }
        }
    }
}