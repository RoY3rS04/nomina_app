﻿using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NominaAPI.Http.Responses;
using NominaAPI.Repository;
using SharedModels;
using SharedModels.DTOs.Nomina;

namespace NominaAPI.Services
{
    public class NominaService
    {
        private readonly Repository<Nomina> _nominaRepository;
        private readonly IMapper _mapper;

        public NominaService(
            Repository<Nomina> nominaRepository,
            IMapper mapper
        )
        {
            _nominaRepository = nominaRepository;
            _mapper = mapper;
        }

        public async Task<NominasResponse> GetAll(int? id, string? fechaRealizacion)
        {
            try
            {
                List<Nomina> nominas;

                if (fechaRealizacion != null && id != null)
                {
                    DateTime realDate = DateTime.Parse(fechaRealizacion);

                    nominas = await _nominaRepository
                        .GetAllAsync(i => i.EmpleadoId == id && (i.FechaRealizacion.Year == realDate.Year &&
                        i.FechaRealizacion.Month == realDate.Month));
                }
                else if (id != null)
                {
                    if (!await _nominaRepository.ExistsAsync(e => e.Id == id))
                    {
                        return new NominasResponse
                        {
                            StatusCode = StatusCodes.Status400BadRequest,
                            Message = $"No existe nómina con id: {id}"
                        };
                    }

                    nominas = await _nominaRepository
                        .GetAllAsync(i => i.EmpleadoId == id);
                }
                else if (fechaRealizacion != null)
                {
                    DateTime realDate = DateTime.Parse(fechaRealizacion);

                    nominas = await _nominaRepository
                        .GetAllAsync(i => i.FechaRealizacion.Year == realDate.Year && i.FechaRealizacion.Month == realDate.Month);
                }
                else
                {
                    nominas = await _nominaRepository.GetAllAsync();
                }

                return new NominasResponse
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Nóminas obtenidas correctamente",
                    Nomina = _mapper.Map<List<NominaDto>>(nominas)
                };
            }
            catch (FormatException)
            {
                return new NominasResponse
                {
                    Message = "Fecha inválida",
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
            catch (Exception)
            {
                return new NominasResponse
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Error al obtener las nóminas"
                };
            }
        }


        public async Task<NominaResponse> GetById(int id)
        {
            if (id <= 0)
            {
                return new NominaResponse
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "El id debe ser un número positivo"
                };
            }

            try
            {
                var nomina = await _nominaRepository.GetById(id);

                if (nomina == null)
                {
                    return new NominaResponse
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = $"No existe una nómina con id: {id}"
                    };
                }

                return new NominaResponse
                {
                    Nomina = _mapper.Map<NominaDto>(nomina),
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Nómina obtenida correctamente"
                };
            }
            catch (Exception)
            {
                return new NominaResponse
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Hubo un error al obtener la nómina"
                };
            }
        }


        public async Task<NominaResponse> Create(NominaCreateDto createDto, ControllerBase controller)
        {
            if (createDto == null)
            {
                return new NominaResponse
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "Por favor ingrese la información requerida"
                };
            }

            try
            {
                if (!controller.ModelState.IsValid)
                {
                    return new NominaResponse
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = "Proporcione la información requerida"
                    };
                }

                var newNomina = _mapper.Map<Nomina>(createDto);

                await _nominaRepository.CreateAsync(newNomina);

                return new NominaResponse
                {
                    Nomina = _mapper.Map<NominaDto>(newNomina),
                    StatusCode = StatusCodes.Status201Created,
                    Message = "Nómina creada correctamente!"
                };
            }
            catch (Exception e)
            {
                return new NominaResponse
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Hubo un error al intentar crear la nómina"
                };
            }
        }


        public async Task<NominaResponse> Update(
            int id,
            JsonPatchDocument<NominaUpdateDto> updatePatch,
            ControllerBase controller
            )
        {
            if (id <= 0)
            {
                return new NominaResponse
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "El id debe de ser un numero positivo"
                };
            }

            try
            {
                var nomina = await _nominaRepository.GetById(id);

                if (nomina == null)
                {
                    return new NominaResponse
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = "No existe nómina con el id recibido"
                    };
                }

                var nominaDto = _mapper.Map<NominaUpdateDto>(nomina);

                updatePatch.ApplyTo(nominaDto, controller.ModelState);

                if (!controller.ModelState.IsValid)
                {
                    return new NominaResponse
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = "Modelo de nómina inválido"
                    };
                }

                _mapper.Map(nominaDto, nomina);

                using (var transaction = await _nominaRepository.BeginTransactionAsync())
                {
                    try
                    {
                        await _nominaRepository.SaveChangesAsync();
                        transaction.Commit();

                        return new NominaResponse
                        {
                            Nomina = _mapper.Map<NominaDto>(nomina),
                            StatusCode = StatusCodes.Status200OK,
                            Message = "Nómina actualizada correctamente"
                        };
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!await _nominaRepository.ExistsAsync(e => e.Id == id))
                        {
                            return new NominaResponse
                            {
                                StatusCode = StatusCodes.Status404NotFound,
                                Message = "No hay nómina con ese id"
                            };
                        }

                        return new NominaResponse
                        {
                            StatusCode = StatusCodes.Status500InternalServerError,
                            Message = "Error al actualizar la nómina"
                        };
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return new NominaResponse
                        {
                            StatusCode = StatusCodes.Status500InternalServerError,
                            Message = "Error al actualizar la nómina"
                        };
                    }
                }
            }
            catch (Exception)
            {
                return new NominaResponse
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Error al actualizar la nómina"
                };
            }
        }


        public async Task<NominaResponse> Delete(int id)
        {
            if (id <= 0)
            {
                return new NominaResponse
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "El id debe de ser un numero positivo"
                };
            }

            try
            {
                var nomina = await _nominaRepository.GetById(id);

                if (nomina == null)
                {
                    return new NominaResponse
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = "No existe nómina con ese id"
                    };
                }

                var relatedNominas = await _nominaRepository.GetAllAsync(n => n.EmpleadoId == nomina.EmpleadoId);

                await _nominaRepository.DeleteRangeAsync(relatedNominas);

                return new NominaResponse
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Nómina y sus relacionadas eliminadas correctamente"
                };
            }
            catch (Exception)
            {
                return new NominaResponse
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Hubo un error al borrar la nómina"
                };
            }
        }

    }
}