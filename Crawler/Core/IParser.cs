namespace FileCrawler.Core
{
    public interface IParser
    {
        void parse(string fileName, string lineContent);
    }
}