using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using FileCrawler.Core.Feature.StringCleaner;
using FileCrawler.Core.Model;
using YamlDotNet.Core.Tokens;

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
            Record("File Name", "Line Found", "Extension", "Full Path", "System Code");
        }
        public void parse(CrawlerResult result)
        {
            var stringContent = _cleaner.clean(result.MatchContent);
            var systemCode = GetCodeSystem(value: stringContent);
            Record(result.FileName, stringContent, result.Extension, result.Path, systemCode);
        }

        private void Record(string name, string content, string extension, string path, string systemCode)
        {
            _csvHelper.WriteField($"{name}",true);
            _csvHelper.WriteField($"{content}",true);
            _csvHelper.WriteField($"{extension}",true);
            _csvHelper.WriteField($"{systemCode}",true);
            //_csvHelper.WriteField($"{path}",true);
            _csvHelper.NextRecord();
        }

        public void WriteFile()
        {
            _csvHelper.Flush();
            _fileStream.Close();
        }

        private string GetCodeSystem(string value)
        {
            var splittedString = value.Split(".");

            if(splittedString.Length > 1)
            {
                var jobNameString = splittedString[1];
                string codeSystem;
                if( jobNameString.Length < 8 )
                    codeSystem = jobNameString.Substring(0, 2);
                else
                    codeSystem = jobNameString.Substring(1, 2);

                return codeSystem;
            }

            return "Not Defined";
        }
    }
}