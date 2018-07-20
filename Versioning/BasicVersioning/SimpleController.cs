using Microsoft.AspNetCore.Mvc;

namespace BasicVersioning
{

    [Route("api/simple")]
    [ApiVersion("1.0")]
    public class SimpleV1Controller : Controller
    {
        public IActionResult Get() => Ok("Version 1");
    }

    [Route("api/simple")]
    [ApiVersion("2.0")]
    public class SimpleV2Controller : Controller
    {
        public IActionResult Get() => Ok("Version 2");
    }
}