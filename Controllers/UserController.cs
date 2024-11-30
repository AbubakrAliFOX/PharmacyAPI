using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PharmacyAPI.Data;
using PharmacyAPI.Data.Repositories.Interfaces;
using PharmacyAPI.Models;

namespace PharmacyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ISeederRepository seedRepo;

        public UserController(ISeederRepository seederRepository)
        {
            seedRepo = seederRepository;
        }

        [HttpGet]
        public ActionResult Seed()
        {
            seedRepo.Seed();
            return Ok("HI");
        }
    }
}
