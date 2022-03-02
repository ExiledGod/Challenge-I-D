using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace DemoDashboardDevice.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly IConfiguration configuration;
        public CompanyController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        
    }
}
