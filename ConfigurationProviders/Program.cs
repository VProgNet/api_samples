using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ConfigurationProviders
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IConfiguration Configuration;
            var someSettings = new Dictionary<string, string>()
            {
                {"poco:key1", "value1"},
                {"poco:key2", "value2"}
            };

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("myConfig.json")
                .AddXmlFile("myConfig.xml")
                .AddIniFile("myConfig.ini")
                .AddCommandLine(args)
                //.AddEnvironmentVariables()
                .AddInMemoryCollection(someSettings)
                .AddUserSecrets("mySecrets");
            Configuration = builder.Build();

            foreach(var item in Configuration.AsEnumerable())
            {
                Console.WriteLine($"Key: {item.Key} Value: {item.Value}");
            }

        }
    }
}
