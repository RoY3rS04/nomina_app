using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModels;
using SharedModels.DTOs;
using SharedModels.DTOs.Deducciones;
using SharedModels.DTOs.Empleado;
using SharedModels.DTOs.Ingresos;
using SharedModels.DTOs.User;

namespace Proyecto_nomina
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        public IRepository<UserDto> Users { get; }
        public IRepository<EmpleadoDto> Empleados { get; }
        public IRepository<IngresosDto> Ingresos { get; }
        public IRepository<DeduccionesDto> Deducciones { get; }
        public IRepository<Nomina> Nominas {  get; }

        public ApiClient()
        {
            string apiBaseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
            _httpClient = new HttpClient { BaseAddress = new Uri(apiBaseUrl) };
            Users = new Repository<UserDto>(_httpClient, "User");
            Empleados = new Repository<EmpleadoDto>(_httpClient, "Empleado");
            Ingresos = new Repository<IngresosDto>(_httpClient, "Ingresos");
            Deducciones = new Repository<DeduccionesDto>(_httpClient, "Deducciones");
            Nominas = new Repository<Nomina>(_httpClient, "Nomina");
        }

    }
}
