using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
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
        private readonly IConfiguration configuration;
        public EmployeController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select name from employe";

            DataTable table = new DataTable();
            string sqlDataSource = this.configuration.GetConnectionString("employeApp");
            MySqlDataReader myReader;
            using (MySqlConnection mySqlConnection = new MySqlConnection(sqlDataSource))
            {
                mySqlConnection.Open();
                using (MySqlCommand mycommand = new MySqlCommand(query, mySqlConnection))
                {
                    myReader = mycommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mySqlConnection.Close();
                }
            }
            return new JsonResult(table);
        }
    }
}
