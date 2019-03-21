using FileCrawler.Core.Model;

namespace FileCrawler.Core
{
    public interface IParser
    {
        void parse(CrawlerResult fileName);
    }
}