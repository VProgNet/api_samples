using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Middleware
{
    public class UpperValueMiddleware
    {
        private readonly RequestDelegate _next;

        public UpperValueMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var value = context.Items["value"].ToString();            
            context.Items["value"] = value.ToUpper();
            await _next(context);
        }
    }
}