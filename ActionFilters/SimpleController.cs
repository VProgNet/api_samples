using Microsoft.AspNetCore.Mvc;

namespace ActionFilters
{
    [Route("api/[controller]")]
    public class SimpleController : Controller
    {
        [HttpGet("")]
        [TimestampFilterAttribute]
        public string Get(string timestamp)
        {
            return $"Request recived at {timestamp}";
        }
    }
}