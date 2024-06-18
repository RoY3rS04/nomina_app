namespace NominaAPI.Http.Responses
{
    public class Response<T>: ApiResponse
    {
        public T? Data { get; set; }
    }
}
