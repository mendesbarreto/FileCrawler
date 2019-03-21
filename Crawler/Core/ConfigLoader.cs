using System;
using System.Collections.Generic;
using System.IO;
using FileCrawler.Core.Model;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace FileCrawler.Core
{
    public class ConfigLoader
    {
        public const string YamlPath = @"config.yaml";

        public Config Load()
        {
            Config config;

            using (var input = new StreamReader(YamlPath))
            {
                var deserializer = new Deserializer(namingConvention: new CamelCaseNamingConvention());
                config = deserializer.Deserialize<Config>(input);
            }

            return config;
        }
    }

}