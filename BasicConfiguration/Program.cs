using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BasicConfiguration
{
    public class Program
    {
        public static IConfigurationRoot Configuration{ get; set;}
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("myConfig.json");
            Configuration = builder.Build();
            foreach (var item in Configuration.AsEnumerable() )
            {
                Console.WriteLine($"Key: {item.Key} Value: {item.Value}");
            }
        }        
    }
}
