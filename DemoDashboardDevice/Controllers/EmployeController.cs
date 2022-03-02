using DemoDashboardDevice.Repositories;
using DemoDashboardDevice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace DemoDashboardDevice.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class EmployeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly Iemploye_repository _employe_repository;
        public EmployeController(Iemploye_repository employe_repository)
        {
            _employe_repository = employe_repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllemployes()
        {
            return Ok(await _employe_repository.GetAllemployes());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployesDetails(int id)
        {
            return Ok(await _employe_repository.GetEmployesDetails(id));
        }
        [HttpPost]
        public async Task<IActionResult> Insertemployes([FromBody] employes employe)
        {
            if (employe == null)
                return BadRequest(); //devuelve estado 400
            if(!ModelState.IsValid)
                return BadRequest(ModelState); //en caso de que un campo requerido o validador no se cumpla
            var created = await _employe_repository.InsertEmployes(employe);
            return Created("created",created); // estado 201
        }
        [HttpPut]
        public async Task<IActionResult> Updateemployes([FromBody] employes employe)
        {
            if (employe == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _employe_repository.UpdateEmployes(employe);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteemployes(int id)
        {
            await _employe_repository.DeleteEmployes(new employes() { id = id });
            return NoContent();
        }
        /*
        [Route("/Savefile")]
        [HttpPost]
        public Task<IActionResult> SaveFile([FromBody] employes employe)
        {
            employes img = JsonConvert.DeserializeObject<employes>(employe.img_ref_validator);
            return 0;
        }
        */

    }
}
