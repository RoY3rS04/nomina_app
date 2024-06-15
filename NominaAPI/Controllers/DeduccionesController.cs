using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NominaAPI.Data;
using NominaAPI.Http.Responses;
using NominaAPI.Repository;
using NominaAPI.Services;
using SharedModels;
using SharedModels.DTOs.Deducciones;
using SharedModels.DTOs.User;

namespace NominaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeduccionesController : ControllerBase
    {
        private readonly DeduccionesService _deduccionesService;
        private readonly NominaContext _context;
        public DeduccionesController(Repository<Deducciones> deduccionesRepository,
            Repository<Empleado> empleadoRepository, NominaContext context,
            IMapper mapper)
        {
            _deduccionesService = new DeduccionesService(deduccionesRepository,
                empleadoRepository,
                mapper);
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DeduccionesResponse>> GetAllDeducciones(int? id, string? fechaCierre)
        {
            var response = await _deduccionesService.GetAll(id,fechaCierre);

            return response.SendResponse(this);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DeduccionesResponse>> GetUserById(int id)
        {

            var response = await _deduccionesService.GetById(id);

            return response.SendResponse(this);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DeduccionResponse>> CreateDeduccion(DeduccionesCreateDto createDto)
        {
            var response = await _deduccionesService.CreateDeduccion(createDto, this);
            return response.SendResponse(this);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DeduccionResponse>> UpdateDeduccion(int id, DeduccionesUpdateDto updateDto)
        {
            var response = await _deduccionesService.UpdateDeduccion(id, updateDto, this);

            return response.SendResponse(this);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DeduccionResponse>> DeleteDeduccion(int id)
        {

            var deduccion = await _context.Deducciones.FindAsync(id);
            if (deduccion == null)
            {
                return NotFound();
            }
            var nominasRelacionadas = await _context.Nominas
                .Where(n => n.DeduccionesId == id)
                .ToListAsync();
            _context.Nominas.RemoveRange(nominasRelacionadas);
            _context.Deducciones.Remove(deduccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
