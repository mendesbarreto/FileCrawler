using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FileCrawler.Core.Feature.Search
{
    public class SCFileSearchPatternMatcher: IStringMatcher
    {
        public IEnumerable<string> Patterns { get; private set; }

        public SCFileSearchPatternMatcher(IEnumerable<string> patterns)
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