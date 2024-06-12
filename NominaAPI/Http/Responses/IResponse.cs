using Microsoft.AspNetCore.Mvc;

namespace NominaAPI.Http.Responses
{
    using Responses;

    public interface IResponse
    {
        public ObjectResult SendResponse(ControllerBase controller);
    }
}
