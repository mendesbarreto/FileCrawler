namespace FileCrawler.Core.Feature.StringCleaner
{
    public class StringIniCleaner: IContentStringCleaner
    {
        public string clean(string value)
        {
            return "";
        }


        private string RemovesVariableFromString()
        {
            var splitedString = value.Split("=");
            return splitedString[1];
        }
    }
}