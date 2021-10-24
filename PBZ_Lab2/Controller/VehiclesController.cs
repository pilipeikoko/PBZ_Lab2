using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PBZ_Lab2.Web.Domain.Models;
using System;
using System.Collections.Generic;
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
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicle()
        {
            return null;
        }

        // GET: api/Vehicles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> GetVehicle(Guid id)
        {
            return null;
        }

        // PUT: api/Vehicles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle(Guid id, Vehicle vehicle)
        {

            return NoContent();
        }

        // POST: api/Vehicles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vehicle>> PostVehicle(Vehicle vehicle)
        {
            return null;
        }

        // DELETE: api/Vehicles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(Guid id)
        {

            return NoContent();
        }

        private bool VehicleExists(Guid id)
        {
            return true;
        }
    }
}
