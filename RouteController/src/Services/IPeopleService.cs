using System.Collections.Generic;

namespace Services
{
    public interface IPeopleService
    {
        IEnumerable<Person> GetAllPeople();
        bool DoesExists(int id);
        bool Validated(Person id);        
        IEnumerable<Person> GetPersoneById(int id);
        void Create(Person persone);

    }
}