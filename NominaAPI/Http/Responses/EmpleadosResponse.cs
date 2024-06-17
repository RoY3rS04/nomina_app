using SharedModels.DTOs.Empleado;

namespace NominaAPI.Http.Responses
{
    public class EmpleadosResponse: ApiResponse
    {
        public List<EmpleadoDto>? Empleados;
    }
}
