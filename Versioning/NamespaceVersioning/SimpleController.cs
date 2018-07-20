using Microsoft.AspNetCore.Mvc;

namespace NamespaceVersioning.Controllers.V1
{  
    [ApiVersion("1.0")]
    [Route("api/simple")]
    public class SimpleController : Controller
    {
        public IActionResult Get() => Ok("Version 1");
    }
}

namespace NamespaceVersioning.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/simple")]

    public class SimpleController : Controller
    {
        public IActionResult Get() => Ok("Version 2");
    }
}