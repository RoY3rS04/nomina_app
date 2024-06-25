using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using NominaAPI.Http.Responses;
using NominaAPI.Repository;
using NominaAPI.Services;
using SharedModels;
using SharedModels.DTOs.Nomina;

namespace NominaAPI.Controllers
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class NominaController : ControllerBase
    {
        private readonly NominaService _nominaService;

        public NominaController(NominaRepository nominaRepository, IMapper mapper)
        {
            _nominaService = new NominaService(nominaRepository, mapper);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<List<NominaDto>>>> GetAll(int? empleadoId, string? fechaRealizacion)
        {
            var response = await _nominaService.GetAll(empleadoId, fechaRealizacion);

            return response.SendResponse(this);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<NominaDto>>> GetById(int id)
        {
            var response = await _nominaService.GetById(id);

            return response.SendResponse(this);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<NominaDto>>> Create(NominaCreateDto createDto)
        {
            var response = await _nominaService.Create(createDto, this);

            return response.SendResponse(this);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<NominaDto>>> Update(int id, JsonPatchDocument<NominaUpdateDto> updateDto)
        {
            var response = await _nominaService.Update(id, updateDto, this);

            return response.SendResponse(this);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<NominaDto>>> Delete(int id)
        {
            var response = await _nominaService.Delete(id);

            return response.SendResponse(this);
        }
    }
}
