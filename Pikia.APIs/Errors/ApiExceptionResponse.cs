namespace Pikia.APIs.Errors
{
    public class ApiExceptionResponse : APIsResponse
    {
        public string Details { get; set; }
        public ApiExceptionResponse(int statusCode, string massage = null, string _details = null) : base(statusCode, massage)
        {
            Details = _details;
        }


    }
}
