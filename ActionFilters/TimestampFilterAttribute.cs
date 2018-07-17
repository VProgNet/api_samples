using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;


namespace ActionFilters
{
    public class TimestampFilterAttribute : Attribute, IAsyncActionFilter, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.ActionDescriptor.RouteValues["timestamp"] = DateTime.Now.ToString();
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var ts = DateTime.Parse(context.ActionDescriptor.RouteValues["timestamp"])
                        .AddHours(1)
                        .ToString();

            context.HttpContext.Response.Headers["X-EXPIRY-TIMESTAMP"] = ts;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            OnActionExecuting(context);
            var resultContext = await next();
            OnActionExecuted(resultContext);
        }
    }
}