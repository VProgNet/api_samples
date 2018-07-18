using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Middleware
{
    public class SkipLineMiddleware 
    {
        private readonly RequestDelegate _next;

        public SkipLineMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync($"Skip line!");
        }
    }
}