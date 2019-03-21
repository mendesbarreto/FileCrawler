using System;
using System.Collections.Generic;
using System.Linq;

namespace FileCrawler.Core
{
    public interface ISearchPatternFactory
    {
        string MakeSearchByExtension();
        IEnumerable<string> MakeStringExtensions();
    }

    public class ExtensionSearchPatternFactory: ISearchPatternFactory
    {
        private readonly IEnumerable<string> _fileExtensions;

        public ExtensionSearchPatternFactory(IEnumerable<string> fileExtensions)
        {
            _fileExtensions = fileExtensions;
        }

        public string MakeSearchByExtension()
        {
            return string.Join(",", MakeStringExtensions());
        }

        public IEnumerable<string> MakeStringExtensions()
        {
            return _fileExtensions.Select(extension => $"*.{extension}");
        }
    }
}