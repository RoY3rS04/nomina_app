using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NominaAPI.Data;
using NominaAPI.Helpers;

namespace NominaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeederController : ControllerBase
    {

        private NominaContext _context;

        public SeederController(NominaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SeedDb()
        {
            Seeder seeder = new Seeder(_context);

            await seeder.SeedDB();

            return Ok();
        }
    }
}
