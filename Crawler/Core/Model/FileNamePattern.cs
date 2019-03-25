using System.Collections.Generic;

namespace FileCrawler.Core.Model
{
    public struct FileNamePattern
    {
        public IEnumerable<string> Names { get; set; }
        public IEnumerable<string> Excludeds { get; set; }
    }
}