using System.Collections.Generic;

namespace FileCrawler.Core.Feature.Search
{
    public interface ISearchPatternFactory
    {
        IEnumerable<string> MakeStringByNameAndExtensions();
        IEnumerable<string> MakeStringByExcludedFiles();
    }
}