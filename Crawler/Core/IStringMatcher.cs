using System.Collections.Generic;

namespace FileCrawler.Core
{
    public interface IStringMatcher
    {
        IEnumerable<string> Patterns { get; }
        bool Match(string value);
    }
}