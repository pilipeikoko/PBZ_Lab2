using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PBZ_Lab2.Web.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PBZ_Lab2.Web.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagersController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ManagersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/Managers
        [HttpGet]
        public async Task<IActionResult> GetManager()
        {
            var query = @"select * from dbo.Manager;";
            
            return await ExecuteQuery(query);
        }

        // GET: api/Managers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetManager(Guid id)
        {
            var query =
                $@"select * from dbo.Manager where Cast(Id as uniqueidentifier) = Cast('{id}' as uniqueidentifier);";
            return await ExecuteQuery(query);
        }

        //todo check

        [HttpPut("{id}")]
        public async Task<IActionResult> PutManager(Guid id, Manager manager)
        {
            var query =
                $@"update dbo.Manager set WorkingYearExperience = '{manager.WorkingYearExperience}',
                FullName = '{manager.FullName}', PhoneNumber = '{manager.PhoneNumber}'
                where Cast(dbo.Manager.Id as uniqueidentifier) = Cast('{id}' as uniqueidentifier);";

            await ExecuteQuery(query);
            return new JsonResult("Updated succesfully");
        }

        // POST: api/Managers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostManager(Manager manager)
        {
            var query = $@"insert into dbo.Manager(Id,WorkingYearExperience,FullName,PhoneNumber) 
                    values (NEWID(),'{manager.WorkingYearExperience}','{manager.FullName}','{manager.PhoneNumber}')";
                            
            await ExecuteQuery(query);
            return new JsonResult("Added succesfully");
        }

        // DELETE: api/Managers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManager(Guid id)
        {
            var query = $@"delete from dbo.Manager where Cast(dbo.Manager.Id as uniqueidentifier) = Cast('{id}' as uniqueidentifier);";

            await ExecuteQuery(query);
            return new JsonResult("Deleted succesfully");
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
