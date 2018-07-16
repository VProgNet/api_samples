using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

using Services;

namespace AttributeRouting.Controllers
{
    [Route("api/[controller]")]
    public class PeopleController
    {
        private readonly IPeopleService _peopleService;
        
        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        //Get api/people
        [HttpGet("")] 
        public IEnumerable<string> Get()
        {
            return _peopleService.GetAllPeople().Select(p => p.Name);
        }

        [HttpGet("{id:int}")]
        public IEnumerable<string> GetPerson(int id)
        {
            return _peopleService.GetPersoneById(id).Select(p => p.Name);
        }

        [HttpGet("top/{n:int}")]
        public IEnumerable<string> GetTopN(int n)
        {
            return _peopleService.GetAllPeople().Take(n).Select(p => p.Name);
        }


        [HttpPost("~/api/person")]
        public IEnumerable<string> Post(Person person)
        {
            _peopleService.Create(person);
            return _peopleService.GetAllPeople().Select(p => p.Name);
        }
    }
}