using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace BluSenseConsole
{
    class Program
    {
        private static IConfigurationRoot _configuration;

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT")}.json", optional : true);

            _configuration = builder.Build();

            // Execute("20190731092510_001L1", "201911181157_001Q", "202003301650_0050.RUO2");
            Execute(args);
        }

        private static void Execute(params string[] names)
        {
            var worker = new ParsingWorker(_configuration);
            foreach (var name in names)
                worker.Execute(name);
        }
    }
}
