using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using CsvHelper;
using CsvHelper.Configuration;
using FileCrawler.Core.Feature.StringCleaner;
using FileCrawler.Core.Model;
using YamlDotNet.Core.Tokens;

namespace FileCrawler.Core.Feature.Parse
{
    public class CVSParser: IParser
    {
        private readonly string _fileName;
        private readonly IContentStringCleaner _cleaner;
        private readonly StreamWriter _fileStream;
        private readonly CsvWriter _csvHelper;
        private readonly Configuration _configuration;

        private List<CrawlerResult> _resultList;

        public CVSParser(string fileName, IContentStringCleaner cleaner)
        {
            _resultList = new List<CrawlerResult>();
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
            _configuration.BufferSize = 2048;
        }

        private void CreateHeader()
        {
            Record("File Name", "Line Found", "Extension", "Full Path", "System Code", "Some");
        }
        public void parse(CrawlerResult result)
        {
            _resultList.Add(CleanResult(result));
        }

        private CrawlerResult CleanResult(CrawlerResult result)
        {
            result.MatchContent = _cleaner.clean(result.MatchContent);
            return result;
        }

        private void Record(string name, string content, string extension, string path, string systemCode, string someThing)
        {
            _csvHelper.WriteField($"{name}",true);
            _csvHelper.WriteField($"{content}",true);
            _csvHelper.WriteField($"{extension}",true);
            _csvHelper.WriteField($"{systemCode}",true);
            _csvHelper.WriteField($"{someThing}",true);
            //_csvHelper.WriteField($"{path}",true);
            _csvHelper.NextRecord();
        }

        public void WriteFile()
        {
            WriteListOnFile();
            _csvHelper.Flush();
            _fileStream.Close();
        }

        private void WriteListOnFile()
        {
            var cleanedList = RemoveDuplicatedData();
            string systemCode;
            string someData;
            foreach (var result in cleanedList)
            {
                someData = GetSomeData(result.FileName);
                systemCode = GetCodeSystem(value: result.MatchContent);
                Record(result.FileName, result.MatchContent, result.Extension, result.Path, systemCode, someData);
            }
        }

        private string GetSomeData(string value)
        {
            var indexOf = value.IndexOf("(");
            var startIndex = indexOf + 2;
            var someDataPlacesCount = 2;
            if (indexOf < 0 || value.Length < indexOf + someDataPlacesCount) return value;

            return value.Substring(startIndex, someDataPlacesCount);
        }

        private IEnumerable<CrawlerResult> RemoveDuplicatedData()
        {
            Console.WriteLine("Removing Duplicated data");

            return _resultList.GroupBy(result => new CrawlerResult()
            {
                    FileName = result.FileName,
                    MatchContent = result.MatchContent,
                    Extension = result.Extension,
                    Path = result.Path

            }).Select( group => group.Key );
        }

        private string GetCodeSystem(string value)
        {
            const string prefix = "A24130.";
            var indexOfValue = value.IndexOf(prefix);
            var stringIndex = indexOfValue + ( prefix.Length );

            if (indexOfValue >= 0)
            {
                return value.Substring(stringIndex, 3);
            }

            return "System code no found";
        }
    }
}