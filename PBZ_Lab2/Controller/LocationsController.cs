using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PBZ_Lab2.Web.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        // GET: api/<LocationsController>
        
        private readonly IConfiguration _configuration;

        public LocationsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LocationsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocation(Guid id)
        {
            var query =
                $@"select * from dbo.Location where Cast(Id as uniqueidentifier) = Cast('{id}' as uniqueidentifier);";
            return await ExecuteQuery(query);
        }

        // POST api/<LocationsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LocationsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LocationsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private async Task<IActionResult> ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("PBZ_Lab2WebContext");
            SqlDataReader reader;

            using (SqlConnection connection = new SqlConnection(sqlDataSource))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    reader = await command.ExecuteReaderAsync();
                    dataTable.Load(reader);

                    reader.Close();
                    connection.Close();
                }
            }

            return new JsonResult(dataTable);
        }
    }
}
