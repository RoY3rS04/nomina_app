using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class DeduccionesController : ControllerBase
    {
        private readonly DeduccionesService _deduccionesService;

        public DeduccionesController(
            Repository<Deducciones> deduccionesRepository,
            Repository<Empleado> empleadoRepository,
            Repository<Nomina> nominaRepository,
            IMapper mapper
        )
        {
            _deduccionesService = new DeduccionesService(
                deduccionesRepository,
                empleadoRepository,
                nominaRepository,
                mapper
            );
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<List<DeduccionesDto>>>> GetAllDeducciones(int? id, string? fechaCierre)
        {
            var response = await _deduccionesService.GetAll(id,fechaCierre);

            return response.SendResponse(this);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<DeduccionesDto>>> GetById(int id)
        {

            var response = await _deduccionesService.GetById(id);

            return response.SendResponse(this);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<DeduccionesDto>>> CreateDeduccion(DeduccionesCreateDto createDto)
        {
            var response = await _deduccionesService.CreateDeduccion(createDto, this);
            return response.SendResponse(this);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<DeduccionesDto>>> UpdateDeduccion(int id, DeduccionesUpdateDto updateDto)
        {
            var response = await _deduccionesService.UpdateDeduccion(id, updateDto, this);

            return response.SendResponse(this);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<DeduccionesDto>>> DeleteDeduccion(int id)
        {

            var response = await _deduccionesService.DeleteDeduccion(id);

            return response.SendResponse(this);
        }
    }
}
