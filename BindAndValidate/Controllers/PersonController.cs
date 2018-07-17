using Microsoft.AspNetCore.Mvc;

using BindAndValidate.DTO;

namespace BindAndValidate.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        public IActionResult Post([FromBody] PersonDTO item)
        {
            if (ModelState.IsValid)
            {
                //do some stuff
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}