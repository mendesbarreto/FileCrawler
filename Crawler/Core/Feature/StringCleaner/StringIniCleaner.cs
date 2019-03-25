using System.Linq;
using System.Text.RegularExpressions;

namespace FileCrawler.Core.Feature.StringCleaner
{
    public class StringIniCleaner: IContentStringCleaner
    {
          //(A24130).*?,
//        private Regex _replacementRegex = new Regex(@"[""'\&,\\/!@()""]|\\s{2,}");
//        private Regex _replacementVariables = new Regex(@"^.*=");
//        private Regex _replacementParentheses = new Regex(@"\).*$");
//        private Regex _regexGet = new Regex(@"(A24130)(.+\w)\w|(A24130)(.+\w)(?=\()");
//        private Regex _regexGet = new Regex(@"(A24130)(.+\w(?=[,]))|(A24130)(.+\w)(?=\()");
//        private Regex _regexGet = new Regex(@"(A24130).*?(?=\()|(A24130).*?(?=[,]+)|(A24130).*?\w(?=[ ])|(A24130)(.+\w)");
        private Regex _regexGet = new Regex(@"(A24130).*?(?=\()|(A24130).*?(?=[,]+)|(A24130).*?\w(?=[=> ])|(A24130)(.+\w)");
//        private Regex _regexGet = new Regex(@"(A24130)(.+\w)(?=\()|(A24130)(.+\w)(?=[,]+)|(A24130)(.+\w)\w(?=[ ])|(A24130)(.+\w)");
//        private Regex _regexGet = new Regex(@"(A24130)(.+\w)");

        public string clean(string value)
        {
            var cleanedString = _regexGet.Match(value).Value;
            return cleanedString;
        }
    }
}