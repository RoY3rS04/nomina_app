using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NominaAPI.Data;
using NominaAPI.Http.Responses;
using NominaAPI.Repository;
using SharedModels;
using SharedModels.DTOs.Deducciones;
using SharedModels.DTOs.Ingresos;
using System.Linq.Expressions;

namespace NominaAPI.Services
{
    public class DeduccionesService
    {
        private readonly Repository<Deducciones> _deduccionesRepository;
        private readonly Repository<Empleado> _empleadoRepository;
        private readonly IMapper _mapper;
        public DeduccionesService(
            Repository<Deducciones> deduccionesRepository,
            Repository<Empleado> userRepository,
            IMapper mapper
        )
        {
            _deduccionesRepository = deduccionesRepository;
            _mapper = mapper;
            _empleadoRepository = userRepository; 
        }

        public async Task<DeduccionesResponse> GetAll(int? id, string? fechaCierre) {

            try
            {
                List<Deducciones> deducciones;

                if (fechaCierre != null && id != null)
                {
                    DateTime realDate = DateTime.Parse(fechaCierre);

                    deducciones = await _deduccionesRepository
                    .GetAllAsync(i => i.EmpleadoId == id && (i.FechaCierre.Year == realDate.Year && i.FechaCierre.Month == realDate.Month));
                }
                else if (id != null)
                {

                    if (!await _empleadoRepository.ExistsAsync(e => e.Id == id))
                    {
                        return new DeduccionesResponse
                        {
                            StatusCode = StatusCodes.Status400BadRequest,
                            Message = $"No existe empleado con id: {id}"
                        };
                    }

                    deducciones = await _deduccionesRepository
                    .GetAllAsync(i => i.EmpleadoId == id);
                } else if (fechaCierre != null)
                {
                    DateTime realDate = DateTime.Parse(fechaCierre);

                    deducciones = await _deduccionesRepository
                    .GetAllAsync(i => i.FechaCierre.Year == realDate.Year && i.FechaCierre.Month == realDate.Month);
                } else
                {
                    deducciones = await _deduccionesRepository.GetAllAsync();
                }

                return new DeduccionesResponse
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Deducciones obtenidas correctamente",
                    Deducciones = _mapper.Map<List<DeduccionesDto>>(deducciones)
                };
            }
            catch (FormatException e)
            {
                return new DeduccionesResponse
                {
                    Message = "Fecha inválida",
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
            catch (Exception e)
            {
                return new DeduccionesResponse
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Error al obtener deducciones"
                };
            }

        }

        public async Task<DeduccionResponse> GetById(int id)
        {
            if (id <= 0)
            {
                return new DeduccionResponse
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "El ID debe ser un número positivo"
                };
            }

            try
            {

                var deduccion = await _deduccionesRepository.GetById(id);

                if (deduccion == null)
                {
                    return new DeduccionResponse
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = "No se encontró ninguna deducción con el ID especificado"
                    };
                }

                return new DeduccionResponse
                {
                    Deduccion = _mapper.Map<DeduccionesDto>(deduccion),
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Deducción obtenida correctamente"
                };
            }
            catch (Exception e)
            {
                return new DeduccionResponse
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Error al obtener la deducción especificada"
                };
            }
        }

        public async Task<DeduccionResponse> CreateDeduccion(DeduccionesCreateDto deduccionCreate, ControllerBase controller)
        {
            if (deduccionCreate == null)
            {
                return new DeduccionResponse
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "Debe proporcionar todos los datos necesarios"
                };
            }
            try
            {
                if (!await _empleadoRepository.ExistsAsync(e => e.Id == deduccionCreate.EmpleadoId))
                {
                    return new DeduccionResponse
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = $"No existe ningún empleado con ID: {deduccionCreate.EmpleadoId}"
                    };
                }
                if (!controller.ModelState.IsValid)
                {
                    return new DeduccionResponse
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = "Modelo de deducción inválido"
                    };
                }
                var nuevaDeduccion = _mapper.Map<Deducciones>(deduccionCreate);
                await _deduccionesRepository.CreateAsync(nuevaDeduccion);

                return new DeduccionResponse
                {
                    Deduccion = _mapper.Map<DeduccionesDto>(nuevaDeduccion),
                    StatusCode = StatusCodes.Status201Created,
                    Message = "Deducción creada exitosamente"
                };
            }
            catch (Exception)
            {
                return new DeduccionResponse
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Ocurrió un error al crear la deducción"
                };
            }
        }

        public async Task<DeduccionResponse> UpdateDeduccion(int id, DeduccionesUpdateDto updateDto, ControllerBase controller)
        {
            if (id <= 0)
            {
                return new DeduccionResponse
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "El ID debe ser un número positivo"
                };
            }
            try
            {

                var deduccion = await _deduccionesRepository.GetById(id);
                if (deduccion == null)
                {
                    return new DeduccionResponse
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = "No se encontró ninguna deducción con el ID especificado"
                    };
                }
                if (!controller.ModelState.IsValid)
                {
                    return new DeduccionResponse
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = "Modelo de deducción inválido"
                    };
                }
                if (updateDto.EmpleadoId != null)
                {
                    if (!await _empleadoRepository.ExistsAsync(e => e.Id == updateDto.EmpleadoId))
                    {
                        return new DeduccionResponse
                        {
                            StatusCode = StatusCodes.Status400BadRequest,
                            Message = "No existe empleado con el id proporcionado"
                        };
                    }
                }
                _mapper.Map(updateDto, deduccion);

                using (var transaction = await _deduccionesRepository.BeginTransactionAsync())
                {
                    try
                    {
                        await _deduccionesRepository.SaveChangesAsync();
                        transaction.Commit();
                        return new DeduccionResponse
                        {
                            Deduccion = _mapper.Map<DeduccionesDto>(deduccion),
                            StatusCode = StatusCodes.Status200OK,
                            Message = "Deducción actualizada exitosamente"
                        };
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!await _deduccionesRepository.ExistsAsync(d => d.Id == id))
                        {
                            return new DeduccionResponse
                            {
                                StatusCode = StatusCodes.Status404NotFound,
                                Message = "No se encontró ninguna deducción con el ID especificado"
                            };
                        }
                        return new DeduccionResponse
                        {
                            StatusCode = StatusCodes.Status400BadRequest,
                            Message = "Ocurrió un error al actualizar la deducción"
                        };
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return new DeduccionResponse
                        {
                            StatusCode = StatusCodes.Status500InternalServerError,
                            Message = "Ocurrió un error al actualizar la deducción"
                        };
                    }
                }
            }
            catch (Exception)
            {
                return new DeduccionResponse
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Ocurrió un error al actualizar la deducción"
                };
            }
        }
        public async Task<DeduccionResponse> DeleteDeduccion(int id)
        {
            if (id <= 0)
            {
                return new DeduccionResponse
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "El ID debe ser un número positivo"
                };
            }
            try
            {
                var deduccion = await _deduccionesRepository.GetById(id);
                if (deduccion == null)
                {
                    return new DeduccionResponse
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = "No se encontró ninguna deducción con el ID especificado"
                    };
                }

                await _deduccionesRepository.DeleteAsync(deduccion);
                return new DeduccionResponse
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Deducción eliminada exitosamente"
                };
            }
            catch (Exception)
            {
                return new DeduccionResponse
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Ocurrió un error al eliminar la deducción"
                };
            }
            
        }
    }
}
