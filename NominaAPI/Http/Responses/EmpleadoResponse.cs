using SharedModels.DTOs.Empleado;

namespace NominaAPI.Http.Responses
{
    public class EmpleadoResponse: ApiResponse
    {
        public EmpleadoDto? Empleado { get; set; }
    }
}
