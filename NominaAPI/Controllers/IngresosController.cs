﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using NominaAPI.Http.Responses;
using NominaAPI.Repository;
using NominaAPI.Services;
using SharedModels;
using SharedModels.DTOs.Ingresos;

namespace NominaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngresosController : ControllerBase
    {
        private readonly IngresosService _ingresosService;

        public IngresosController(
            Repository<Ingresos> ingresosRepository,
            Repository<Empleado> empleadoRepository,
            Repository<Nomina> nominaRepository,
            IMapper mapper
        ) { 
            _ingresosService = new IngresosService(
                ingresosRepository,
                empleadoRepository,
                nominaRepository,
                mapper
            );
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IngresosResponse>> GetAll(int? empleadoId, string? fechaCierre)
        {
            var response = await _ingresosService.GetAll(empleadoId, fechaCierre);

            return response.SendResponse(this);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IngresoResponse>> GetById(int id)
        {
            var response = await _ingresosService.GetById(id);

            return response.SendResponse(this);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IngresoResponse>> Create(IngresosCreateDto createDto)
        {
            var response = await _ingresosService.Create(createDto, this);

            return response.SendResponse(this);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IngresoResponse>> Update(int id, JsonPatchDocument<IngresosUpdateDto> updateDto)
        {
            var response = await _ingresosService.Update(id, updateDto, this);

            return response.SendResponse(this);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IngresoResponse>> Delete(int id)
        {
            var response = await _ingresosService.Delete(id);

            return response.SendResponse(this);
        }
    }
}
