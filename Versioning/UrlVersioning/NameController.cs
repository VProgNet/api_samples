using Microsoft.AspNetCore.Mvc;

namespace UrlVersioning
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    public class NameController : Controller
    {
        [MapToApiVersion("1.0")]
        public IActionResult Get() => Ok("Version 1");

        [MapToApiVersion("2.0")]
        public IActionResult Put(string name) => Ok("Version 2");
    }
}