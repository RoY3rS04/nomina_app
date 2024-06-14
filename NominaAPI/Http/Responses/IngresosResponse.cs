using SharedModels.DTOs.Ingresos;

namespace NominaAPI.Http.Responses
{
    public class IngresosResponse: ApiResponse
    {
        public List<IngresosDto>? Ingresos { get; set; }
    }
}
