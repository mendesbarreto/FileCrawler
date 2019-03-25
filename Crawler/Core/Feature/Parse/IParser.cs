using FileCrawler.Core.Model;

namespace FileCrawler.Core.Feature.Parse
{
    public interface IParser
    {
        void parse(CrawlerResult fileName);
    }
}