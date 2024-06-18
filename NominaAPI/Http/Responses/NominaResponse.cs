using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SharedModels;
using SharedModels.DTOs.Nomina;

namespace NominaAPI.Http.Responses
{
    public class NominaResponse: ApiResponse
    {
        public NominaDto? Nomina { get; set; }
    }
}
