using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace JWT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var webHost = WebHost.CreateDefaultBuilder(args) 
                .ConfigureAppConfiguration((webHostBuilderContext, configurationbuilder) =>  
                {  
                    var environment = webHostBuilderContext.HostingEnvironment; 
                    string envName = environment.EnvironmentName;
                     
                    string appsettingsPath = Path.Combine(environment.ContentRootPath,"appsettings");  
                    configurationbuilder  
                            .AddJsonFile(Path.Combine(appsettingsPath,"appsettings.json"), optional: false, reloadOnChange: true)  
                            .AddJsonFile(Path.Combine(appsettingsPath,$"appsettings.{envName}.json"), optional: true, reloadOnChange: true);
                })  
                .UseStartup<Startup>();
            return webHost;            
        }             
    }
}
