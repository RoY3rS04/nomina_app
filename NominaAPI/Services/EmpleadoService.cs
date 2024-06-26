﻿using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NominaAPI.Http.Responses;
using NominaAPI.Repository;
using SharedModels;
using SharedModels.DTOs.Empleado;
using SharedModels.DTOs.Ingresos;
using SharedModels.DTOs.User;

namespace NominaAPI.Services
{
    public class EmpleadoService
    {
        private readonly Repository<Empleado> _empleadoRepository;
        private readonly Repository<Ingresos> _ingresosRepository;
        private readonly Repository<Deducciones> _deduccionesRepository;
        private readonly Repository<Nomina> _nominaRepository;
        private readonly IMapper _mapper;

        public EmpleadoService(
            Repository<Empleado> empleadoRepository,
            Repository<Ingresos> ingresosRepository,
            Repository<Deducciones> deduccionesRepository,
            Repository<Nomina> nominaRepository,
            IMapper mapper
        )
        {
            _empleadoRepository = empleadoRepository;
            _ingresosRepository = ingresosRepository;
            _deduccionesRepository = deduccionesRepository;
            _nominaRepository = nominaRepository; 
            _mapper = mapper;
        }

        public async Task<Response<List<EmpleadoDto>>> GetAll(string? codigoEmp, string? cedulaEmp)
        {
            try
            {

                List<Empleado> empleados;

                if (codigoEmp != null && cedulaEmp != null)
                {
                    empleados = await _empleadoRepository.GetAllAsync(
                        e => e.CodigoEmpleado == codigoEmp && e.Cedula == cedulaEmp
                    );
                }
                else if (codigoEmp != null)
                {
                    empleados = await _empleadoRepository.GetAllAsync(
                        e => e.CodigoEmpleado == codigoEmp
                    );
                }
                else if (cedulaEmp != null)
                {
                    empleados = await _empleadoRepository.GetAllAsync(
                        e => e.Cedula == cedulaEmp
                    );
                }
                else
                {
                    empleados = await _empleadoRepository.GetAllAsync();
                }

                return new Response<List<EmpleadoDto>>
                {
                    Data = _mapper.Map<List<EmpleadoDto>>(empleados),
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Empleados obtenidos correctamente!"
                };
            }
            catch (Exception e)
            {
                return new Response<List<EmpleadoDto>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Hubo un error al obtener los empleados"
                };
            }
        }

        public async Task<Response<EmpleadoDto>> GetById(int id)
        {
            if(id <= 0)
            {
                return new Response<EmpleadoDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "El id debe de ser un numero positivo"
                };
            }

            try
            {

                var empleado = await _empleadoRepository.GetById(id);

                if(empleado == null)
                {
                    return new Response<EmpleadoDto>
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = $"No existe un empleado con id: {id}"
                    };
                }

                return new Response<EmpleadoDto>
                {
                    Data = _mapper.Map<EmpleadoDto>(empleado),
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Empleado obtenido correctamente!"
                };

            } catch(Exception e)
            {
                return new Response<EmpleadoDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Hubo un error al obtener el empleado"
                };
            }
        }

        public async Task<Response<EmpleadoDto>> Create(EmpleadoCreateDto createDto, ControllerBase controller)
        {
            if(createDto == null)
            {
                return new Response<EmpleadoDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "Por favor ingrese la informacion requerida"
                };
            }

            try
            {

                var empleadoExists = await _empleadoRepository.ExistsAsync(
                    e => e.Cedula == createDto.Cedula ||
                    e.NumeroINSS == createDto.NumeroINSS ||
                    e.NumeroRUC == createDto.NumeroRUC ||
                    e.CodigoEmpleado == createDto.CodigoEmpleado
                );

                if (empleadoExists)
                {
                    return new Response<EmpleadoDto>
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = "Ya existe un empleado con esas identificaciones"
                    };
                }

                if(!controller.ModelState.IsValid)
                {
                    return new Response<EmpleadoDto>
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = "Proporcione la informacion requerida"
                    };
                }

                var newEmpleado = _mapper.Map<Empleado>(createDto);

                await _empleadoRepository.CreateAsync(newEmpleado);

                return new Response<EmpleadoDto>
                {
                    Data = _mapper.Map<EmpleadoDto>(newEmpleado),
                    StatusCode = StatusCodes.Status201Created,
                    Message = "Empleado creado correctamente!"
                };

            } catch(Exception e)
            {
                return new Response<EmpleadoDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Hubo un error al intentar crear el empleado"
                };
            }
        }

        public async Task<Response<EmpleadoDto>> Update(
            int id,
            EmpleadoUpdateDto updateDto,
            ControllerBase controller
        )
        {
            if (id <= 0)
            {
                return new Response<EmpleadoDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "El id debe de ser un numero positivo"
                };
            }

            try
            {

                var empleado = await _empleadoRepository.GetById(id);

                if (empleado == null)   
                {
                    return new Response<EmpleadoDto>
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = "No existe empleado con el id que se recibio"
                    };
                }

                _mapper.Map(updateDto, empleado);

                using (var transaction = await _empleadoRepository.BeginTransactionAsync())
                {
                    try
                    {

                        await _empleadoRepository.SaveChangesAsync();
                        transaction.Commit();

                        return new Response<EmpleadoDto>
                        {
                            Data = _mapper.Map<EmpleadoDto>(empleado),
                            StatusCode = StatusCodes.Status200OK,
                            Message = "Empleado actualizado correctamente!"
                        };

                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!await _empleadoRepository.ExistsAsync(e => e.Id == id))
                        {
                            return new Response<EmpleadoDto>
                            {
                                StatusCode = StatusCodes.Status404NotFound,
                                Message = "No hay ingresos con ese id"
                            };
                        }

                        return new Response<EmpleadoDto>
                        {
                            StatusCode = StatusCodes.Status500InternalServerError,
                            Message = "Hubo un error al actualizar el empleado"
                        };
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();

                        return new Response<EmpleadoDto>
                        {
                            StatusCode = StatusCodes.Status500InternalServerError,
                            Message = "Hubo un error al actualizar el empleado"
                        };
                    }
                }

            }
            catch (Exception e)
            {
                return new Response<EmpleadoDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Hubo un error al actualizar el empleado"
                };
            }
        }

        public async Task<Response<EmpleadoDto>> Delete(int id)
        {
            if (id <= 0)
            {
                return new Response<EmpleadoDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "El id debe de ser un numero positivo"
                };
            }

            try
            {
                var empleado = await _empleadoRepository.GetById(id);

                if (empleado == null)
                {
                    return new Response<EmpleadoDto>
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = "No existe empleado con ese id"
                    };
                }

                var relatedNominas = await _nominaRepository.GetAllAsync(n => n.EmpleadoId == empleado.Id);
                var relatedIngresos = await _ingresosRepository.GetAllAsync(i => i.EmpleadoId == empleado.Id);
                var relatedDeducciones = await _deduccionesRepository.GetAllAsync(d => d.EmpleadoId == empleado.Id);

                await _nominaRepository.DeleteRangeAsync(relatedNominas);
                await _ingresosRepository.DeleteRangeAsync(relatedIngresos);
                await _deduccionesRepository.DeleteRangeAsync(relatedDeducciones);
                await _empleadoRepository.DeleteAsync(empleado);

                return new Response<EmpleadoDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Empleado y sus ingresos, deducciones y nominas relacionadas eliminados correctamente!"
                };
            }
            catch (Exception e)
            {
                return new Response<EmpleadoDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Hubo un error al borrar el empleado"
                };
            }
        }
    }
}
