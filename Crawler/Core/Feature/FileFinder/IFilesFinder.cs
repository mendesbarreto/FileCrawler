using System.Collections.Generic;
using System.IO;

namespace FileCrawler.Core.Feature.FileFinder
{
    public interface IFilesFinder {
        IEnumerable<FileInfo> GetFiles();
    }
}