using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FileCrawler.Core.Feature.Search;

namespace FileCrawler.Core.Feature.FileFinder
{
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
            var stringByNameAndExtensions = _searchPatternFactory.MakeStringByNameAndExtensions();
            var excludeFilesNames = _searchPatternFactory.MakeStringByExcludedFiles();

            IEnumerable<string> files = new List<string>();

            foreach (var stringPattern in stringByNameAndExtensions)
            {
                Console.WriteLine($"Trying to find files with the pattern: {stringPattern}");
                files = files.Concat(Directory.EnumerateFiles(rootDirectory,
                                                             stringPattern,
                                                             SearchOption.AllDirectories));
            }

            files = RemoveExcludedFiles(files, excludeFilesNames);

            return files;
        }

        private IEnumerable<string> RemoveExcludedFiles(IEnumerable<string> fileNames,
                                                    IEnumerable<string> fileNameExcludeds)
        {
            return fileNames.Where(fileName =>
            {
                var isExcludedFile = false;

                foreach (var excludeFilesName in fileNameExcludeds)
                {
                    if(!excludeFilesName.Any() || !fileName.Contains(excludeFilesName)) continue;
                    isExcludedFile = true;
                }
                //Console.WriteLine($"File name {fileName} exclude: {isExcludedFile}");
                return !isExcludedFile;
            });
        }

    }
}