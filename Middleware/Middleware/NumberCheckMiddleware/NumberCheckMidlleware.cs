using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Middleware
{
    public class NumberCheckerMiddleware
    {
        private readonly RequestDelegate _next;
        public NumberCheckerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var value = context.Request.Query["value"].ToString();
            if (int.TryParse(value, out int intValue))
            {
                await context.Response.WriteAsync($"You entered a number: {intValue}");
            }
            else
            {
                context.Items["value"] = value;
                await _next(context);
            }
        }
    }
}