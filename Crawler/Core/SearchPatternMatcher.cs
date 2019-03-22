using System.Collections.Generic;
using System.Linq;

namespace FileCrawler.Core
{
    public class SearchPatternMatcher: IStringMatcher
    {
        public IEnumerable<string> Patterns { get; private set; }

        public SearchPatternMatcher(IEnumerable<string> patterns)
        {
            Patterns = patterns;
        }

        public bool Match(string value)
        {
            var hasStringValue = false;

            foreach (var pattern in Patterns)
            {
                if ( !value.Contains(pattern) || !value.Any()) continue;
                hasStringValue = true;
            }

            return hasStringValue;
        }
    }
}