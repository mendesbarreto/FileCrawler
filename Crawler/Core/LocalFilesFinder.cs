using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileCrawler.Core
{
    public interface IFilesFinder {
        IEnumerable<FileInfo> GetFiles();
    }

    public class LocalFilesFinder: IFilesFinder
    {
        private readonly string _rootDirectory;
        private readonly ISearchPatternFactory _searchPatternFactory;

        public LocalFilesFinder(string rootDirectory, ISearchPatternFactory searchPatternFactory)
        {
            _rootDirectory = rootDirectory;
            _searchPatternFactory = searchPatternFactory;
        }

        public IEnumerable<FileInfo> GetFiles()
        {
            return GetFilesNames().Select( fileName => new FileInfo(fileName));
        }

        private IEnumerable<string> GetFilesNames()
        {
            var rootDirectory = _rootDirectory;
            var stringPatterns = _searchPatternFactory.MakeStringExtensions();
            IEnumerable<string> files = new List<string>();

            foreach (var stringPattern in stringPatterns)
            {
                files = files.Concat(Directory.EnumerateFiles(rootDirectory,
                                                             stringPattern,
                                                             SearchOption.AllDirectories));
            }

            return files;
        }

    }
}