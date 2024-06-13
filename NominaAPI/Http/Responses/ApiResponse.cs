using Microsoft.AspNetCore.Mvc;

namespace NominaAPI.Http.Responses
{
    using Http.Responses;

    public abstract class ApiResponse: IResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ObjectResult SendResponse(ControllerBase controller)
        {
            switch (StatusCode)
            {
                case StatusCodes.Status200OK:
                    return controller.Ok(this);
                case StatusCodes.Status201Created:
                    return controller.CreatedAtAction(null, this);
                case StatusCodes.Status400BadRequest:
                    return controller.BadRequest(this);
                case StatusCodes.Status404NotFound:
                    return controller.NotFound(this);
                case StatusCodes.Status401Unauthorized:
                    return controller.Unauthorized(this);
                case StatusCodes.Status500InternalServerError:
                    return controller.StatusCode(StatusCode, this);
                default: return null;
            }
        }
    }
}
