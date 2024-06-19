using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using NominaAPI.Http.Responses;
using NominaAPI.Repository;
using NominaAPI.Services;
using SharedModels;
using SharedModels.DTOs.Empleado;

namespace NominaAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {

        private readonly EmpleadoService _empleadoService;

        public EmpleadoController(
            Repository<Empleado> empleadoRepository,
            Repository<Ingresos> ingresosRepository,
            Repository<Deducciones> deduccionesRepository,
            Repository<Nomina> nominaRepository,
            IMapper mapper
        )
        {
            _empleadoService = new EmpleadoService(
                empleadoRepository,
                ingresosRepository,
                deduccionesRepository,
                nominaRepository,
                mapper
            );
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<List<EmpleadoDto>>>> GetAll(string? codigoEmp, string? cedulaEmp)
        {
            var response = await _empleadoService.GetAll(codigoEmp, cedulaEmp);

            return response.SendResponse(this);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<EmpleadoDto>>> GetById(int id)
        {
            var response = await _empleadoService.GetById(id);

            return response.SendResponse(this);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<EmpleadoDto>>> Create(EmpleadoCreateDto createDto)
        {
            var response = await _empleadoService.Create(createDto, this);

            return response.SendResponse(this);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<EmpleadoDto>>> Update(int id, EmpleadoUpdateDto updatePatch)
        {
            var response = await _empleadoService.Update(id, updatePatch, this);

            return response.SendResponse(this);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<EmpleadoDto>>> Delete(int id)
        {
            var response = await _empleadoService.Delete(id);

            return response.SendResponse(this);
        }
    }
}
