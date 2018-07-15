using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

using AwesomeSauce.Components;
using AwesomeSauce.Interfaces;
using AwesomeSauce.NumberCheckerMiddleware;

namespace AwesomeSauce
{
    public class CustomStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddSingleton<IComponent, ComponentB>();
            services.AddSingleton<IComponent, ComponentC>();
            
        }
        public void Configure(IApplicationBuilder app, IComponent component)
        {
            app.UseNumberChecker();
            
            app.MapWhen(c => c.Request.Path == "/foo/bar" && c.Request.Method == "GET", config =>
            {
                config.Run(async (context) =>
                {
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync("Hello World!\n");
                });
            })
            .Run(async (context) =>
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("Not Found\nc");
            }
            );

            

        }
    }
}