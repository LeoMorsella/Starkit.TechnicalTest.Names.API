using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Persistence.Services;

namespace App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly PersonService personService;

        public PersonController(PersonService personService)
        {
            this.personService = personService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetPeople([FromQuery] Gender? gender, [FromQuery] string? startsWith = "")
        {
            try
            {
                var people = personService.FilterPerson(gender, startsWith);
                return Ok(people);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }
    }
}
