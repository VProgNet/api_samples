using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class PeopleService : IPeopleService
    {
        private List<Person> _personList;
        public PeopleService()
        {
            _personList = new List<Person>();
            _personList.Add(new Person{Id = 1, Name = "Sam"});
            _personList.Add(new Person{Id = 2, Name = "John"});
            _personList.Add(new Person{Id = 3, Name = "Trevor"});
        }
        public void Create(Person persone)
        {
            //fake implementation
            //add person data here
            if (!_personList.Contains(persone))
            {
                _personList.Add(persone);
            }
        }

        public bool DoesExists(int id)
        {            
            //fake implementation
            return true;
        }

        public IEnumerable<Person> GetAllPeople()
        {
            //fake implementation
            return _personList;
        }

        public IEnumerable<Person> GetPersoneById(int id)
        {
            //fake implementation
            return _personList.Where(person => person.Id == id);
        }

        public bool Validated(Person id)
        {
            //fake implementation
            return true;
        }
    }
}