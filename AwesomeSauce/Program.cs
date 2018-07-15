using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using AwesomeSauce.Server;
using System.Reflection;

namespace AwesomeSauce
{
    public class Program
    {
        static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseAwesomeServer(o => o.FolderPath = $"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}"+"/root")
                .UseStartup<CustomStartup>()
            .Build();
    }
}
