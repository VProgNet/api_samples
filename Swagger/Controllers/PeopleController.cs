using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swagger.Models;

namespace Swagger.Controllers
{
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {
        [HttpGet]
        [Produces(typeof(IEnumerable<PersonDTO>))]
        public IActionResult Get()
        {
            return Ok(new PersonDTO[] {});
        }

        [HttpGet("{id}")]
        [Produces(typeof(PersonDTO))]
        public IActionResult Get(int id)
        {
            return Ok(new PersonDTO { Id = 1, Name = "Simple"});
        }

        [HttpPost]
        public IActionResult Post([FromBody]PersonDTO person)
        {
            return CreatedAtAction(nameof(Get), new { id = person.Id });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PersonDTO person)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}