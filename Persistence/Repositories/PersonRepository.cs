using Models;
using Newtonsoft.Json;
using System.Globalization;

namespace Persistence
{
    public class PersonRepository
    {
        private readonly List<Person> response;

        public PersonRepository()
        {
            string relativePath = "Data\\names.json";
            string absolutePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
            var personJson = File.ReadAllText(absolutePath);
            response = JsonConvert.DeserializeObject<Response>(personJson).people;
        }

        public IEnumerable<Person> GetPeople(Gender? gender, string letterOfName = "")
        {
            TextInfo myTI = new CultureInfo("es-AR").TextInfo;
            var query = response.AsQueryable();
            if (gender.HasValue)
            {
                query = query.Where(x => x.Gender == gender.Value);
            }
            if (!string.IsNullOrEmpty(letterOfName))
            {

                query = query.Where(x => x.Name.StartsWith(myTI.ToTitleCase(letterOfName.ToLower())));
            }
            return query.ToList();
        }
    }
}
