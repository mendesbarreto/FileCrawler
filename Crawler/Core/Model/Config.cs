using System.Collections.Generic;

namespace FileCrawler.Core.Model
{
    public struct Config
    {
        public string RootPath { get; set; }
        public IEnumerable<string> Extensions { get; set; }
        public IEnumerable<string> SearchPatterns { get; set; }
        public string OutputName { get; set; }
    }
}