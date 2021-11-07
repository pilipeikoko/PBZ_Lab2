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
    public class VehiclesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public VehiclesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/Vehicles
        [HttpGet]
        public async Task<IActionResult> GetVehicle()
        {
            var query = @"select * from dbo.Vehicle;";

            return await ExecuteQuery(query);
        }

        // GET: api/Vehicles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(Guid id)
        {
            var query =
                $@"select * from dbo.Vehicle where Cast(Id as uniqueidentifier) = Cast('{id}' as uniqueidentifier);";
            return await ExecuteQuery(query);
        }

        // PUT: api/Vehicles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle(Guid id, Vehicle vehicle)
        {
            var locationGuid = Guid.NewGuid();
            var query = $@"insert into dbo.Location (Id,Latitude, Longitude) values 
                        (Cast('{locationGuid}' as uniqueidentifier),'{vehicle.Location.Latitude}','{vehicle.Location.Longitude}');";
            await ExecuteQuery(query);

            var query1 =
                $@"update dbo.Vehicle set RegistrationNumber = '{vehicle.RegistrationNumber}',
                LocationId = '{locationGuid}'
                where Cast(dbo.Vehicle.Id as uniqueidentifier) = Cast('{id}' as uniqueidentifier);";

            await ExecuteQuery(query1);
            return new JsonResult("Updated succesfully");
        }

        // POST: api/Vehicles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostVehicle(Vehicle vehicle)
        {
            var locationGuid = Guid.NewGuid();
            var query = $@"insert into dbo.Location (Id,Latitude, Longitude) values 
                        (Cast('{locationGuid}' as uniqueidentifier),'{vehicle.Location.Latitude}','{vehicle.Location.Longitude}');";
            await ExecuteQuery(query);

            var query1 = $@"insert into dbo.Vehicle(Id,RegistrationNumber,LocationId) 
                    values (NEWID(),'{vehicle.RegistrationNumber}','{locationGuid}')";

            await ExecuteQuery(query1);
            return new JsonResult("Added succesfully");
        }

        // DELETE: api/Vehicles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(Guid id)
        {
            var query = $@"delete from dbo.Vehicle where Cast(dbo.Vehicle.Id as uniqueidentifier) = Cast('{id}' as uniqueidentifier);";

            await ExecuteQuery(query);
            return new JsonResult("Deleted succesfully");
        }

        private async Task<IActionResult> ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("PBZ_Lab2WebContext");
            SqlDataReader reader;

            await using (SqlConnection connection = new SqlConnection(sqlDataSource))
            {
                connection.Open();
                await using (SqlCommand command = new SqlCommand(query, connection))
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
