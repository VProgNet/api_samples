using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace StronglyTypedConfiguration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("myConfig.json");
            
            var myOptions = new MyOptions();
            builder.Build().Bind(myOptions);

            Console.WriteLine($"Foo: {myOptions.Foo}");
            Console.WriteLine($"Bar: {myOptions.Bar}");
            Console.WriteLine($"Baz:Fuz: {myOptions.Baz.Faz}");
        }
    }
}
