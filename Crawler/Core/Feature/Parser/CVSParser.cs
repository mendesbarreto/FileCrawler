using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using FileCrawler.Core.Feature.StringCleaner;
using FileCrawler.Core.Model;

namespace FileCrawler.Core
{
    public class CVSParser: IParser
    {
        private readonly string _fileName;
        private readonly IContentStringCleaner _cleaner;
        private readonly StreamWriter _fileStream;
        private readonly CsvWriter _csvHelper;
        private readonly Configuration _configuration;
        public CVSParser(string fileName, IContentStringCleaner cleaner)
        {
            _fileName = fileName;
            _cleaner = cleaner;
            _configuration = new Configuration();

            SetupCsvFile();

            _fileStream = new StreamWriter(_fileName);
            _csvHelper = new CsvWriter(_fileStream, _configuration);

            CreateHeader();
        }

        private void SetupCsvFile()
        {
            _configuration.Delimiter = ";";
        }

        private void CreateHeader()
        {
            Record("File Name", "Line Found", "Extension", "Full Path");
        }
        public void parse(CrawlerResult result)
        {
            var stringContent = _cleaner.clean(result.MatchContent);
            Record(result.FileName, stringContent, result.Extension, result.Path);
        }

        private void Record(string name, string content, string extension, string path)
        {
            _csvHelper.WriteField($"{name}",true);
            _csvHelper.WriteField($"{content}",true);
            _csvHelper.WriteField($"{extension}",true);
            //_csvHelper.WriteField($"{path}",true);
            _csvHelper.NextRecord();
        }

        public void WriteFile()
        {
            _csvHelper.Flush();
            _fileStream.Close();
        }
    }
}