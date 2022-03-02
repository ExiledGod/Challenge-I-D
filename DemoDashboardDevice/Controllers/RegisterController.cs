using DemoDashboardDevice.Repositories;
using DemoDashboardDevice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Threading.Tasks;

namespace DemoDashboardDevice.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly Ihistory_repository _history_repository;
        public RegisterController(Ihistory_repository history_repository)
        {
            _history_repository = history_repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllemployes()
        {
            return Ok(await _history_repository.GetAllHistory());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployesDetails(int id)
        {
            return Ok(await _history_repository.GetHistoryDetails(id));
        }
        [HttpPost]
        public async Task<IActionResult> Insertemployes([FromBody] register register)
        {
            if (register == null)
                return BadRequest(); //devuelve estado 400
            if (!ModelState.IsValid)
                return BadRequest(ModelState); //en caso de que un campo requerido o validador no se cumpla
            var created = await _history_repository.InsertHistory(register);
            return Created("created", created); // estado 201
        }
        [HttpPut]
        public async Task<IActionResult> Updateemployes([FromBody] register register)
        {
            if (register == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _history_repository.UpdateHistory(register);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteemployes(int id)
        {
            await _history_repository.DeleteHistory(new register() { id = id });
            return NoContent();
        }
    }
}
