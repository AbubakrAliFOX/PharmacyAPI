using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PharmacyAPI.Data.Repositories.Interfaces;

namespace PharmacyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SeedController : ControllerBase
    {
        private readonly ISeederRepository _seeder;

        public SeedController(ISeederRepository seeder)
        {
            _seeder = seeder;
        }

        [HttpGet]
        public async Task<ActionResult> Seed()
        {
            await _seeder.Seed();
            await _seeder.BindUsersWithBranches();
            return Ok("Seeded!");
        }
    }
}
