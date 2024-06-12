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

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> SeedDb()
        {

            try
            {
                await _seeder.SeedDB();

                return Ok("Database seeded sucessfully!");
            } catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong when seeding DB");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete]
        public async Task<IActionResult> ClearDb()
        {
           try
            {
                await _seeder.ClearDB();

                return Ok("Database cleared successfully!");
            } catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong when clearing DB");
            }
        }
    }
}
