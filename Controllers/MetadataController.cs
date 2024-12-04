using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PharmacyAPI.Services;

namespace PharmacyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetadataController : ControllerBase
    {
        private readonly MetadataService _metaService;

        public MetadataController(MetadataService metaService)
        {
            _metaService = metaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserMetadata()
        {
            var userMetadata = await _metaService.GetUserMetadata();
            return Ok(userMetadata);
        }
    }
}
