using System.Linq;
using System.Text.RegularExpressions;

namespace FileCrawler.Core.Feature.StringCleaner
{
    public class StringIniCleaner: IContentStringCleaner
    {
        private Regex _replacementRegex = new Regex(@"['\&,\\/!@()]|\\s{2,}");
        private Regex _replacementVariables = new Regex(@"^.*=");
        private Regex _replacementParentheses = new Regex(@"\).*$");

        public string clean(string value)
        {
            var cleanedString = _replacementVariables.Replace(value, "");
            cleanedString = _replacementParentheses.Replace(cleanedString, "");
            cleanedString = _replacementRegex.Replace(cleanedString, "");
            return cleanedString;
        }

        private string RemoveStringParentheses(string value)
        {
            var splitedString = value.Split("(");
            if( splitedString.Length > 1 && splitedString[0].Any() )
            {
                return splitedString[0];
            }

            return value;
        }

        private string RemovesVariableFromString(string value)
        {
            var splitedString = value.Split("=");
            if(splitedString.Length > 1 && splitedString[1].Any() )
            {
                return splitedString[1];
            }
            return value;
        }
    }
}