using Microsoft.AspNetCore.Mvc;
using Services;
namespace Conventions.CustomControllers
{
    public class NameApi
    {
        private readonly IPeopleService _peopleService;
        public NameApi(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        public IActionResult Get()
        {
            var people = _peopleService.GetAllPeople();
            return new OkObjectResult(people);
        }
    }
}