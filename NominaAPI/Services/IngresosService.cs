using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NominaAPI.Http.Responses;
using NominaAPI.Repository;
using SharedModels;
using SharedModels.DTOs.Ingresos;
using System.Data;

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

        public async Task<IngresoResponse> Create(IngresosCreateDto createDto, ControllerBase controller)
        {
            if(createDto == null)
            {
                return new IngresoResponse
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "Por favor envie la informacion necesaria"
                };
            }

            try
            {

                if(!await _empleadoRepository.ExistsAsync(e => e.Id == createDto.EmpleadoId))
                {
                    return new IngresoResponse
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = "No existe el empleado al que se quieren agregar los ingresos"
                    };
                }

                if(!controller.ModelState.IsValid)
                {
                    return new IngresoResponse
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = "Modelo de ingresos invalido"
                    };
                }

                var newIngreso = _mapper.Map<Ingresos>(createDto);

                await _ingresosRepository.CreateAsync(newIngreso);

                return new IngresoResponse
                {
                    Ingreso = _mapper.Map<IngresosDto>(newIngreso),
                    StatusCode = StatusCodes.Status201Created,
                    Message = "Ingresos agregados correctamente al empleado"
                };
            } catch(Exception e)
            {
                return new IngresoResponse
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Error al crear ingresos"
                };
            }
        }

        public async Task<IngresoResponse> Update(
            int id,
            IngresosUpdateDto updateDto,
            ControllerBase controller
        )
        {
            if(id <= 0)
            {
                return new IngresoResponse
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "El id debe de ser un numero positivo"
                };
            }

            try
            {

                var ingresos = await _ingresosRepository.GetById(id);

                if( ingresos == null )
                {
                    return new IngresoResponse
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = "No existen ingresos con el id que se recibio"
                    };
                }

                if (!controller.ModelState.IsValid)
                {
                    return new IngresoResponse
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = "Modelo de ingresos invalido"
                    };
                }

                if(updateDto.EmpleadoId != null)
                {
                    if(!await _empleadoRepository.ExistsAsync(e => e.Id == updateDto.EmpleadoId))
                    {
                        return new IngresoResponse
                        {
                            StatusCode = StatusCodes.Status400BadRequest,
                            Message = "No existe empleado con el id proporcionado"
                        };
                    }
                }

                //TODO REFACTORING
                updateDto = new IngresosUpdateDto
                {
                    Bonos = updateDto.Bonos ?? ingresos.Bonos,
                    Comision = updateDto.Comision ?? ingresos.Comision,
                    Depreciacion = updateDto.Depreciacion ?? ingresos.Depreciacion,
                    DiasExtras = updateDto.DiasExtras ?? ingresos.DiasExtras,
                    EmpleadoId = updateDto.EmpleadoId ?? ingresos.EmpleadoId,
                    FechaCierre = updateDto.FechaCierre ?? ingresos.FechaCierre,
                    HorasExtras = updateDto.HorasExtras ?? ingresos.HorasExtras,
                    Nocturnidad = updateDto.Nocturnidad ?? ingresos.Nocturnidad,
                    RiesgoLaboral=updateDto.RiesgoLaboral ?? ingresos.RiesgoLaboral,
                    SalarioOrdinario = updateDto.SalarioOrdinario ?? ingresos.SalarioOrdinario,
                    Viatico = updateDto.Viatico ?? ingresos.Viatico
                };

                _mapper.Map(updateDto, ingresos);

                using(var transaction = await _ingresosRepository.BeginTransactionAsync())
                {
                    try
                    {

                        await _ingresosRepository.SaveChangesAsync();
                        transaction.Commit();

                        return new IngresoResponse
                        {
                            Ingreso = _mapper.Map<IngresosDto>(ingresos),
                            StatusCode = StatusCodes.Status200OK,
                            Message = "Ingresos actualizados correctamente!"
                        };

                    } catch(DbUpdateConcurrencyException) {
                        if (!await _ingresosRepository.ExistsAsync(i => i.Id == id))
                        {
                            return new IngresoResponse
                            {
                                StatusCode = StatusCodes.Status404NotFound,
                                Message = "No hay ingresos con ese id"
                            };
                        }

                        return new IngresoResponse
                        {
                            StatusCode = StatusCodes.Status500InternalServerError,
                            Message = "Hubo un error al actualizar los ingresos"
                        };
                    }
                    catch(Exception e)
                    {
                        transaction.Rollback();

                        return new IngresoResponse
                        {
                            StatusCode = StatusCodes.Status500InternalServerError,
                            Message = "Hubo un error al actualizar los ingresos"
                        };
                    }
                }

            } catch (Exception e)
            {
                return new IngresoResponse
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Hubo un error al actualizar los ingresos"
                };
            }
        }

        public async Task<IngresoResponse> Delete(int id)
        {
            if (id <= 0)
            {
                return new IngresoResponse
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "El id debe de ser un numero positivo"
                };
            }

            try
            {
                var ingresos = await _ingresosRepository.GetById(id);

                if(ingresos == null)
                {
                    return new IngresoResponse
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = "No existen ingresos con ese id"
                    };
                }

                await _ingresosRepository.DeleteAsync(ingresos);

                return new IngresoResponse
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Ingresos eliminados correctamente!"
                };
            } catch(Exception e)
            {
                return new IngresoResponse
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Hubo un error al borrar los ingresos"
                };
            }
        }
    }
}
