using System.Collections.Generic;

namespace FileCrawler.Core.Feature.Search
{
    public interface IStringMatcher
    {
        IEnumerable<string> Patterns { get; }
        bool Match(string value);
    }
}