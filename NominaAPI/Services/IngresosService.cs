using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NominaAPI.Http.Responses;
using NominaAPI.Repository;
using SharedModels;
using SharedModels.DTOs.Ingresos;

namespace NominaAPI.Services
{
    public class IngresosService
    {
        private readonly Repository<Ingresos> _ingresosRepository;
        private readonly Repository<Empleado> _empleadoRepository;
        private readonly IMapper _mapper;

        public IngresosService(
            Repository<Ingresos> ingresosRepository,
            Repository<Empleado> userRepository,
            IMapper mapper
        )
        {
            _ingresosRepository = ingresosRepository;
            _mapper = mapper;
            _empleadoRepository = userRepository;
        }

        //TODO - REFACTOR 
        public async Task<IngresosResponse> GetAll(int? id, string? fechaCierre) {

            try
            {
                List<Ingresos> ingresos;

                if (fechaCierre != null && id != null)
                {
                    DateTime realDate = DateTime.Parse(fechaCierre);

                    ingresos = await _ingresosRepository
                    .GetAllAsync(i => i.EmpleadoId == id && (i.FechaCierre.Year == realDate.Year && i.FechaCierre.Month == realDate.Month));
                }
                else if(id != null)
                {

                    if(!await _empleadoRepository.ExistsAsync(e => e.Id == id))
                    {
                        return new IngresosResponse
                        {
                            StatusCode = StatusCodes.Status400BadRequest,
                            Message = "No existe empleado con id: {id}"
                        };
                    }

                    ingresos = await _ingresosRepository
                    .GetAllAsync(i => i.EmpleadoId == id);
                } else if(fechaCierre != null)
                {
                    DateTime realDate = DateTime.Parse(fechaCierre);

                    ingresos = await _ingresosRepository
                    .GetAllAsync(i => i.FechaCierre.Year == realDate.Year && i.FechaCierre.Month == realDate.Month);
                } else
                {
                    ingresos = await _ingresosRepository.GetAllAsync();
                }

                return new IngresosResponse
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Ingresos obtenidos correctamente",
                    Ingresos = _mapper.Map<List<IngresosDto>>(ingresos)
                };
            }
            catch (FormatException e)
            {
                return new IngresosResponse
                {
                    Message = "Fecha invalida",
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
            catch (Exception e)
            {
                return new IngresosResponse
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Error al obtener ingresos"
                };
            }

        }

        public async Task<IngresoResponse> GetById(int id)
        {
            if (id <= 0)
            {
                return new IngresoResponse
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "El id debe ser un numero mayor a 0"
                };
            }

            try
            {

                var ingreso = await _ingresosRepository.GetById(id);

                if (ingreso == null)
                {
                    return new IngresoResponse
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = "No existen ingresos con el id especificado"
                    };
                }

                return new IngresoResponse
                {
                    Ingreso = _mapper.Map<IngresosDto>(ingreso),
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Ingreso obtenido correctamente!"
                };
            }
            catch (Exception e)
            {
                return new IngresoResponse
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Error al obtener el ingreso especificado"
                };
            }
        }
    }
}
