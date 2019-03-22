using System;
using System.Collections.Generic;
using System.Linq;

namespace FileCrawler.Core
{
    public interface ISearchPatternFactory
    {
        IEnumerable<string> MakeStringByNameAndExtensions();
    }

    public class FileNameAndExtensionSearchPatternFactory: ISearchPatternFactory
    {
        private readonly IEnumerable<string> _fileNamePatterns;

        public FileNameAndExtensionSearchPatternFactory(IEnumerable<string> fileNamePatterns)
        {
            _fileNamePatterns = fileNamePatterns;
        }

        public IEnumerable<string> MakeStringByNameAndExtensions()
        {
            return _fileNamePatterns.Select(filename =>
            {
                if (filename == "*") return $"{filename}.*";
                return $"*{filename}*.*";
            });
        }
    }
}