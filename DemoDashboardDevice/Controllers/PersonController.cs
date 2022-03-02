using DemoDashboardDevice.Models;
using DemoDashboardDevice.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DemoDashboardDevice.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly Iperson_repository _person_repository;
        public PersonController(Iperson_repository person_repository)
        {
            _person_repository = person_repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllemployes()
        {
            return Ok(await _person_repository.GetAllPerson());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployesDetails(int id)
        {
            return Ok(await _person_repository.GetPersonDetails(id));
        }
        [HttpPost]
        public async Task<IActionResult> Insertemployes([FromBody] Person person)
        {
            if (person == null)
                return BadRequest(); //devuelve estado 400
            if (!ModelState.IsValid)
                return BadRequest(ModelState); //en caso de que un campo requerido o validador no se cumpla
            var created = await _person_repository.InsertPerson(person);
            return Created("created", created); // estado 201
        }
        [HttpPut]
        public async Task<IActionResult> Updateemployes([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _person_repository.UpdatePerson(person);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteemployes(int id)
        {
            await _person_repository.DeletePerson(new Person() { id = id });
            return NoContent();
        }
        [Route("/byIdenty")]
        [HttpGet("{id}")]
        public async Task<IActionResult> FilterPersonByIdentifier([FromBody] Person person)
        {
            if (person == null)
                return BadRequest(); //devuelve estado 400
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(await _person_repository.FilterPersonByIdentifier(person));
        }
        [Route("/byCompany")]
        [HttpGet("{id}")]
        public async Task<IActionResult> FilterPersonByCompany([FromBody] Person person)
        {
            if (person == null)
                return BadRequest(); //devuelve estado 400
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(await _person_repository.FilterPersonByCompany(person));
        }
    }
}
