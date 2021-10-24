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
    public class ManagersController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ManagersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/Managers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manager>>> GetManager()
        {
            return null;
        }

        // GET: api/Managers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Manager>> GetManager(Guid id)
        {
            return null;
        }

        // PUT: api/Managers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManager(Guid id, Manager manager)
        {


            return NoContent();
        }

        // POST: api/Managers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Manager>> PostManager(Manager manager)
        {
            return NoContent();
        }

        // DELETE: api/Managers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManager(Guid id)
        {
            return NoContent();
        }

        private bool ManagerExists(Guid id)
        {
            return true;
        }
    }
}
