using System;
using System.Collections.Generic;
using System.Linq;

namespace FileCrawler.Core
{
    public interface ISearchPatternFactory
    {
        string MakeSearchByExtension();
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
            var patternByExtension = _fileExtensions.Select(extension => $"*.{extension}");
            return string.Join(",", patternByExtension);
        }
    }
}