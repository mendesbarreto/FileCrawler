namespace FileCrawler.Core.Model
{
    public struct CrawlerResult
    {
        public string FileName { get; set; }
        public string MatchContent { get; set; }
        public string Extension { get; set; }
        public string Path { get; set; }
    }
}