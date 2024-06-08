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
        private Seeder _seeder;

        public SeederController(NominaContext context)
        {
            _context = context;
            _seeder = new Seeder(_context);
        }

        [HttpPost]
        public async Task<IActionResult> SeedDb()
        {

            await _seeder.SeedDB();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> ClearDb()
        {
            await _seeder.ClearDB();

            return Ok();
        }
    }
}
