using SharedModels;
using SharedModels.DTOs.Deducciones;
using SharedModels.DTOs.Ingresos;

namespace NominaAPI.Http.Responses
{
    public class DeduccionesResponse: ApiResponse
    {
        public List<DeduccionesDto>? Deducciones { get; set; }

    }
}
