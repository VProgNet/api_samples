using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Middleware
{
    public class VowelMaskerMiddleware
    {
        private readonly RequestDelegate _next;

        public VowelMaskerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var value = context.Items["value"].ToString();
            context.Items["value"] = Regex.Replace(value, "(?<!^)[AEUI](?!$)", "*");
            await _next(context);
        }
    }
}