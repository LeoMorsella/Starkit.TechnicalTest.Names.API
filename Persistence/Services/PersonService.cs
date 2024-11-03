using Models;

namespace Persistence.Services
{
    public class PersonService
    {
        private readonly PersonRepository repository;

        public PersonService(PersonRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Person> FilterPerson(Gender? gender, string letterOfName)
        {
            return repository.GetPeople(gender, letterOfName);
        }
    }
}
