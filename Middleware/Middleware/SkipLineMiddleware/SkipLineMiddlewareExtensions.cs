using Microsoft.AspNetCore.Builder;

namespace Middleware
{
    public static class SkipLineMiddlewareExtensions
    {
        public static IApplicationBuilder UseSkipLine(this IApplicationBuilder app)
        {
            return app.UseMiddleware<SkipLineMiddleware>();
        }
    }
}