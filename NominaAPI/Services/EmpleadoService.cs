using AutoMapper;
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
            _mapper = mapper;
            _ingresosRepository = ingresosRepository;
            _deduccionesRepository = deduccionesRepository;
            _nominaRepository = nominaRepository;
        }

        public async Task<EmpleadosResponse> GetAll()
        {
            try
            {

                var empleados = await _empleadoRepository.GetAllAsync();

                return new EmpleadosResponse
                {
                    Empleados = _mapper.Map<List<EmpleadoDto>>(empleados),
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Empleados obtenidos correctamente!"
                };
            }
            catch (Exception e)
            {
                return new EmpleadosResponse
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Hubo un error al obtener los empleados"
                };
            }
        }

        public async Task<EmpleadoResponse> GetById(int id)
        {
            if(id <= 0)
            {
                return new EmpleadoResponse
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
                    return new EmpleadoResponse
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = $"No existe un empleado con id: {id}"
                    };
                }

                return new EmpleadoResponse
                {
                    Empleado = _mapper.Map<EmpleadoDto>(empleado),
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "Empleado obtenido correctamente!"
                };

            } catch(Exception e)
            {
                return new EmpleadoResponse
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Hubo un error al obtener el empleado"
                };
            }
        }

        public async Task<EmpleadoResponse> Create(EmpleadoCreateDto createDto, ControllerBase controller)
        {
            if(createDto == null)
            {
                return new EmpleadoResponse
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
                    return new EmpleadoResponse
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = "Ya existe un empleado con esas identificaciones"
                    };
                }

                if(!controller.ModelState.IsValid)
                {
                    return new EmpleadoResponse
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = "Proporcione la informacion requerida"
                    };
                }

                var newEmpleado = _mapper.Map<Empleado>(createDto);

                await _empleadoRepository.CreateAsync(newEmpleado);

                return new EmpleadoResponse
                {
                    Empleado = _mapper.Map<EmpleadoDto>(newEmpleado),
                    StatusCode = StatusCodes.Status201Created,
                    Message = "Empleado creado correctamente!"
                };

            } catch(Exception e)
            {
                return new EmpleadoResponse
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Hubo un error al intentar crear el empleado"
                };
            }
        }

        public async Task<EmpleadoResponse> Update(
            int id,
            JsonPatchDocument<EmpleadoUpdateDto> updatePatch,
            ControllerBase controller
        )
        {
            if (id <= 0)
            {
                return new EmpleadoResponse
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
                    return new EmpleadoResponse
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = "No existe empleado con el id que se recibio"
                    };
                }

                var empleadoDto = _mapper.Map<EmpleadoUpdateDto>(empleado);

                updatePatch.ApplyTo(empleadoDto, controller.ModelState);

                if (!controller.ModelState.IsValid)
                {
                    return new EmpleadoResponse
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = "Modelo de empleado invalido"
                    };
                }

                _mapper.Map(empleadoDto, empleado);

                using (var transaction = await _empleadoRepository.BeginTransactionAsync())
                {
                    try
                    {

                        await _empleadoRepository.SaveChangesAsync();
                        transaction.Commit();

                        return new EmpleadoResponse
                        {
                            Empleado = _mapper.Map<EmpleadoDto>(empleado),
                            StatusCode = StatusCodes.Status200OK,
                            Message = "Empleado actualizado correctamente!"
                        };

                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!await _empleadoRepository.ExistsAsync(e => e.Id == id))
                        {
                            return new EmpleadoResponse
                            {
                                StatusCode = StatusCodes.Status404NotFound,
                                Message = "No hay ingresos con ese id"
                            };
                        }

                        return new EmpleadoResponse
                        {
                            StatusCode = StatusCodes.Status500InternalServerError,
                            Message = "Hubo un error al actualizar el empleado"
                        };
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();

                        return new EmpleadoResponse
                        {
                            StatusCode = StatusCodes.Status500InternalServerError,
                            Message = "Hubo un error al actualizar el empleado"
                        };
                    }
                }

            }
            catch (Exception e)
            {
                return new EmpleadoResponse
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Hubo un error al actualizar el empleado"
                };
            }
        }

        public async Task<EmpleadoResponse> Delete(int id)
        {
            if (id <= 0)
            {
                return new EmpleadoResponse
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
                    return new EmpleadoResponse
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

                return new EmpleadoResponse
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Empleado y sus ingresos, deducciones y nominas relacionadas eliminados correctamente!"
                };
            }
            catch (Exception e)
            {
                return new EmpleadoResponse
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Hubo un error al borrar el empleado"
                };
            }
        }
    }
}
