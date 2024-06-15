using SharedModels;
using SharedModels.DTOs.Deducciones;

namespace NominaAPI.Http.Responses
{
    public class DeduccionResponse: ApiResponse
    {
        public DeduccionesDto? Deduccion { get; set; }
    }
}
