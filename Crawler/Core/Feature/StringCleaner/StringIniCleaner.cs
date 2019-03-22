namespace FileCrawler.Core.Feature.StringCleaner
{
    public class StringIniCleaner: IContentStringCleaner
    {
        public string clean(string value)
        {
            var cleanedString = RemovesVariableFromString(value);
            cleanedString = RemoveStringParentheses(cleanedString);

            return cleanedString;
        }

        private string RemoveStringParentheses(string value)
        {
            var splitedString = value.Split("(");
            return splitedString[0];
        }


        private string RemovesVariableFromString(string value)
        {
            var splitedString = value.Split("=");
            if(splitedString.Length > 1) return splitedString[1];
            return value;
        }
    }
}