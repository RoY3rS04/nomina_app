using SharedModels;
using SharedModels.DTOs.Ingresos;

namespace NominaAPI.Http.Responses
{
    public class IngresoResponse: ApiResponse
    {
        public IngresosDto? Ingreso { get; set; }
    }
}
