using System.Collections.Generic;

namespace FileCrawler.Core.Model
{
    public struct FileNamePattern
    {
        public IEnumerable<string> Names { get; set; }
        public IEnumerable<string> Excludeds { get; set; }
    }

    public struct Config
    {
        public string RootPath { get; set; }
        public FileNamePattern FileNamePattern { get; set; }
        public IEnumerable<string> SearchPatterns { get; set; }
        public string OutputName { get; set; }
    }
}