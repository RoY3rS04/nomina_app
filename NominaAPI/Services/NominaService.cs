using AutoMapper;
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
        private readonly NominaRepository _nominaRepository;
        private readonly Repository<Ingresos> _ingresosRepository;
        private readonly Repository<Deducciones> _deduccionesRepository;
        private readonly IMapper _mapper;

        public NominaService(
            NominaRepository nominaRepository,
            Repository<Ingresos> ingresosRepository,
            Repository<Deducciones> deduccionesRepository,
            IMapper mapper
        )
        {
            _nominaRepository = nominaRepository;
            _ingresosRepository = ingresosRepository;
            _deduccionesRepository = deduccionesRepository;
            _mapper = mapper;
        }

        public async Task<Response<List<NominaDto>>> GetAll(int? empleadoId, string? fechaRealizacion)
        {
            try
            {
                List<Nomina> nominas;

                if (fechaRealizacion != null && empleadoId != null)
                {
                    DateTime realDate = DateTime.Parse(fechaRealizacion);

                    nominas = await _nominaRepository
                        .GetPopulatedNominas(i => i.EmpleadoId == empleadoId && (i.FechaRealizacion.Year == realDate.Year &&
                        i.FechaRealizacion.Month == realDate.Month));
                }
                else if (empleadoId != null)
                {
                    if (!await _nominaRepository.ExistsAsync(e => e.EmpleadoId == empleadoId))
                    {
                        return new Response<List<NominaDto>>
                        {
                            StatusCode = StatusCodes.Status400BadRequest,
                            Message = $"No existe nómina con id: {empleadoId}"
                        };
                    }

                    nominas = await _nominaRepository
                        .GetPopulatedNominas(i => i.EmpleadoId == empleadoId);
                }
                else if (fechaRealizacion != null)
                {
                    DateTime realDate = DateTime.Parse(fechaRealizacion);

                    nominas = await _nominaRepository
                        .GetPopulatedNominas(i => i.FechaRealizacion.Year == realDate.Year && i.FechaRealizacion.Month == realDate.Month);
                }
                else
                {
                    nominas = await _nominaRepository.GetPopulatedNominas();
                }

                return new Response<List<NominaDto>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Nóminas obtenidas correctamente",
                    Data = _mapper.Map<List<NominaDto>>(nominas)
                };
            }
            catch (FormatException)
            {
                return new Response<List<NominaDto>>
                {
                    Message = "Fecha inválida",
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
            catch (Exception)
            {
                return new Response<List<NominaDto>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Error al obtener las nóminas"
                };
            }
        }


        public async Task<Response<NominaDto>> GetById(int id)
        {
            if (id <= 0)
            {
                return new Response<NominaDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "El id debe ser un número positivo"
                };
            }

            try
            {
                var nomina = await _nominaRepository.GetByIdPopulated(id);

                if (nomina == null)
                {
                    return new Response<NominaDto>
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = $"No existe una nómina con id: {id}"
                    };
                }

                return new Response<NominaDto>
                {
                    Data = _mapper.Map<NominaDto>(nomina),
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Nómina obtenida correctamente"
                };
            }
            catch (Exception)
            {
                return new Response<NominaDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Hubo un error al obtener la nómina"
                };
            }
        }


        public async Task<Response<NominaDto>> Create(NominaCreateDto createDto, ControllerBase controller)
        {
            if (createDto == null)
            {
                return new Response<NominaDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "Por favor ingrese la información requerida"
                };
            }

            try
            {
                if (!controller.ModelState.IsValid)
                {
                    return new Response<NominaDto>
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = "Proporcione la información requerida"
                    };
                }

                var newNomina = _mapper.Map<Nomina>(createDto);

                await _nominaRepository.CreateAsync(newNomina);

                return new Response<NominaDto>
                {
                    Data = _mapper.Map<NominaDto>(newNomina),
                    StatusCode = StatusCodes.Status201Created,
                    Message = "Nómina creada correctamente!"
                };
            }
            catch (Exception e)
            {
                return new Response<NominaDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Hubo un error al intentar crear la nómina"
                };
            }
        }


        public async Task<Response<NominaDto>> Update(
            int id,
            NominaUpdateDto updateDto,
            ControllerBase controller
            )
        {
            if (id <= 0)
            {
                return new Response<NominaDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "El id debe de ser un numero positivo"
                };
            }

            try
            {
                var nomina = await _nominaRepository.GetByIdPopulated(id);

                if (nomina == null)
                {
                    return new Response<NominaDto>
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = "No existe nómina con el id recibido"
                    };
                }

                _mapper.Map(updateDto, nomina);

                if (!controller.ModelState.IsValid)
                {
                    return new Response<NominaDto>
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = "Modelo de nómina inválido"
                    };
                }

                using (var transaction = await _nominaRepository.BeginTransactionAsync())
                {
                    try
                    {
                        await _nominaRepository.SaveChangesAsync();
                        transaction.Commit();

                        return new Response<NominaDto>
                        {
                            Data = _mapper.Map<NominaDto>(nomina),
                            StatusCode = StatusCodes.Status200OK,
                            Message = "Nómina actualizada correctamente"
                        };
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!await _nominaRepository.ExistsAsync(e => e.Id == id))
                        {
                            return new Response<NominaDto>
                            {
                                StatusCode = StatusCodes.Status404NotFound,
                                Message = "No hay nómina con ese id"
                            };
                        }

                        return new Response<NominaDto>
                        {
                            StatusCode = StatusCodes.Status500InternalServerError,
                            Message = "Error al actualizar la nómina"
                        };
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return new Response<NominaDto>
                        {
                            StatusCode = StatusCodes.Status500InternalServerError,
                            Message = "Error al actualizar la nómina"
                        };
                    }
                }
            }
            catch (Exception)
            {
                return new Response<NominaDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Error al actualizar la nómina"
                };
            }
        }


        public async Task<Response<NominaDto>> Delete(int id)
        {
            if (id <= 0)
            {
                return new Response<NominaDto>
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
                    return new Response<NominaDto>
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = "No existe nómina con ese id"
                    };
                }

                await _nominaRepository.DeleteAsync(nomina);

                var relatedIngresos = await _ingresosRepository.GetById(nomina.IngresosId);
                var relatedDeducciones = await _deduccionesRepository.GetById(nomina.DeduccionesId);

                await _ingresosRepository.DeleteAsync(relatedIngresos);
                await _deduccionesRepository.DeleteAsync(relatedDeducciones);

                return new Response<NominaDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Nómina eliminada correctamente"
                };
            }
            catch (Exception)
            {
                return new Response<NominaDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Hubo un error al borrar la nómina"
                };
            }
        }

    }
}
