using System;
using System.Collections.Generic;
using System.IO;
using FileCrawler.Core.Model;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace FileCrawler.Core.Feature.Setup
{
    public class ConfigLoader
    {
        public const string YamlPath = @"config.yaml";

        public Config Load()
        {
            Config config;
            var deserializer = new Deserializer(namingConvention: new CamelCaseNamingConvention(), ignoreUnmatched: true);

            using (var input = new StreamReader(YamlPath))
            {
                config = deserializer.Deserialize<Config>(input);
            }

            return config;
        }
    }

}