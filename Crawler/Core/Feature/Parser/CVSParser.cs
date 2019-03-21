using System.IO;
using CsvHelper;
using FileCrawler.Core.Model;

namespace FileCrawler.Core
{
    public class CVSParser: IParser
    {
        private readonly string _fileName;
        private StreamWriter _fileStream;
        private CsvWriter _csvHelper;

        public CVSParser(string fileName)
        {
            _fileName = fileName;
            _fileStream = new StreamWriter(_fileName);
            _csvHelper = new CsvWriter(_fileStream);
            CreateHeader();
        }

        private void CreateHeader()
        {
            Record("File Name", "Line Found", "Extension", "Full Path");
        }
        public void parse(CrawlerResult result)
        {
            Record(result.FileName, result.MatchContent, result.Extension, result.Path);
        }

        private void Record(string name, string content, string extension, string path)
        {
            _csvHelper.WriteField($"{name}",true);
            _csvHelper.WriteField($"{content}",true);
            _csvHelper.WriteField($"{extension}",true);
            _csvHelper.WriteField($"{path}",true);
            _csvHelper.NextRecord();
        }

        public void WriteFile()
        {
            _csvHelper.Flush();
            _fileStream.Close();
        }
    }
}