using System;
using System.Collections.Generic;
using System.Linq;
using FileCrawler.Core.Model;

namespace FileCrawler.Core.Feature.Search
{
    public class FileNameAndExtensionSearchPatternFactory: ISearchPatternFactory
    {
        private readonly FileNamePattern _fileNamePatterns;

        public FileNameAndExtensionSearchPatternFactory(FileNamePattern fileNamePatterns)
        {
            _fileNamePatterns = fileNamePatterns;
        }

        public IEnumerable<string> MakeStringByNameAndExtensions()
        {
            return _fileNamePatterns.Names.Select(filename =>
            {
                if (filename == "*") return $"{filename}.*";
                return $"*{filename}*.*";
            });
        }

        public IEnumerable<string> MakeStringByExcludedFiles()
        {
            return _fileNamePatterns.Excludeds;
        }
    }
}