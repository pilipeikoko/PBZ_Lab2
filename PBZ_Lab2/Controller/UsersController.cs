using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PBZ_Lab2.Web.Domain.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PBZ_Lab2.Web.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var query = @"select * from dbo.CarUser;";
            return await ExecuteQuery(query);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var query = @$"select dbo.CarUser.Id, dbo.CarUser.isBlocker, dbo.CarUser.PassportPhoto, dbo.CarUser.DrivingLicensePhoto,
                                dbo.CarUser.DrivingYearExperience,dbo.CarUser.Rating,dbo.CarUser.FullName,dbo.CarUser.PhoneNumber,
                                dbo.CarUser.LocationId,dbo.CarUser.ManagerId, loc.Latitude, loc.Longitude,manager.FullName,manager.PhoneNumber,
                                manager.WorkingYearExperience from dbo.CarUser inner join dbo.Location loc on dbo.CarUser.LocationId = loc.Id
                                left join dbo.Manager manager on(dbo.CarUser.ManagerId is not NULL and manager.Id = dbo.CarUser.ManagerId) where
                                Cast(dbo.CarUser.Id as uniqueidentifier) = Cast('{id.ToString()}' as uniqueidentifier);";
            return await ExecuteQuery(query);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(Guid id, User user)
        {
            var query =
                $@"update dbo.CarUser set PassportPhoto = '{user.PassportPhoto}',DrivingLicensePhoto = '{user.DrivingLicensePhoto}',
                DrivingYearExperience = '{user.DrivingYearExperience}',isBlocker = '{user.isBlocker}',Rating = '{user.Rating}',
                FullName = '{user.FullName}', PhoneNumber = '{user.PhoneNumber}'
                where Cast(dbo.CarUser.Id as uniqueidentifier) = Cast('{id}' as uniqueidentifier);";

            await ExecuteQuery(query);
            return new JsonResult("Updated succesfully");
        }

        [HttpPut("link/{managerId}")]
        public async Task<IActionResult> LinkManager(Guid managerId,User user)
        {
            var query =
                $@"update dbo.CarUser set ManagerId = Cast('{managerId}' as uniqueidentifier)  where Cast(dbo.CarUser.Id as uniqueidentifier) = Cast('{user.Id}' as uniqueidentifier);";

            await ExecuteQuery(query);
            return new JsonResult("Updated succesfully");
        }

        [HttpPost]
        public async Task<IActionResult> PostUser(User user)
        {
            var locationGuid = Guid.NewGuid();
            var query = $@"insert into dbo.Location (Id,Latitude, Longitude) values 
                        (Cast('{locationGuid}' as uniqueidentifier),'{user.Location.Latitude}','{user.Location.Longitude}');";
            await ExecuteQuery(query);

            var query1 = $@"insert into dbo.CarUser(Id,PassportPhoto,DrivingLicensePhoto,DrivingYearExperience,isBlocker,Rating,FullName,PhoneNumber,LocationId) 
                    values (NEWID(),'{user.PassportPhoto}','{user.DrivingLicensePhoto}','{user.DrivingYearExperience}','{user.isBlocker}','{user.Rating}','{user.FullName}','{user.PhoneNumber}',Cast('{locationGuid}' as uniqueidentifier))";

            await ExecuteQuery(query1);
            return new JsonResult("Added succesfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var query = $@"delete from dbo.CarUser where Cast(dbo.CarUser.Id as uniqueidentifier) = Cast('{id}' as uniqueidentifier);";

            await ExecuteQuery(query);
            return new JsonResult("Deleted succesfully");
        }

        [HttpPost("location/{userId}")]
        public async Task<IActionResult> AddLocation(Guid userId, Location location)
        {
            var locationGuid = Guid.NewGuid();
            var query = $@"insert into dbo.Location (Id,Latitude, Longitude) values 
                        (Cast('{locationGuid}' as uniqueidentifier),'{location.Latitude}','{location.Longitude}');";
            await ExecuteQuery(query);

            var query2 = $@"update dbo.CarUser set LocationId = Cast('{locationGuid}' as uniqueidentifier)
                where Cast(dbo.CarUser.Id as uniqueidentifier) = Cast('{userId}' as uniqueidentifier);";
            await ExecuteQuery(query2);

            return new JsonResult("Added succesfully");
        }

        [HttpPost("manager/{userId}")]
        public async Task<IActionResult> AddManager(Guid userId, Manager manager)
        {
            //its not correct
            var managerGuid = Guid.NewGuid();
            var query = $@"insert into dbo.Manager (Id,WorkingYearExperience, FullName,PhoneNumber) values 
                        (Cast('{managerGuid}' as uniqueidentifier),'{manager.WorkingYearExperience}','{manager.FullName}','{manager.PhoneNumber}');";
            await ExecuteQuery(query);

            var query2 = $@"update dbo.CarUser set ManagerId = Cast('{managerGuid}' as uniqueidentifier)
                where Cast(dbo.CarUser.Id as uniqueidentifier) = Cast('{userId}' as uniqueidentifier);";
            await ExecuteQuery(query2);

            return new JsonResult("Added succesfully");
        }



        [HttpGet("manager/{managerId}")]
        public async Task<IActionResult> GetLinkedUsers(Guid managerId)
        {
            var query =
                $"select * from dbo.CarUser where Cast(dbo.CarUser.ManagerId as uniqueidentifier) = Cast('{managerId}' as uniqueidentifier);";

            return await ExecuteQuery(query);
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
