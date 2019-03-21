using System.Collections.Generic;
using System.Linq;

namespace FileCrawler.Core
{
    public class SearchPatternMatcher: IStringMatcher
    {
        private readonly IEnumerable<string> _patterns;

        public SearchPatternMatcher(IEnumerable<string> patterns)
        {
            _patterns = patterns;
        }

        public bool Match(string value)
        {
            var hasStringValue = false;

            foreach (var pattern in _patterns)
            {
                if (!value.Contains(pattern) || !value.Any() ) continue;
                hasStringValue = true;
            }

            return hasStringValue;
        }
    }
}