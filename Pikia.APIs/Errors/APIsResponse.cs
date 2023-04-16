using System;

namespace Pikia.APIs.Errors
{
    public class APIsResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public APIsResponse(int statusCode , string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A Bad Request , you have made",
                401 => "Authorized you are not",
                404=> "Resourse found , it was not",
                500 => "Errors are the path to dark side. Errors lead to enger. Anger leads to hate. Hate leads to career change", 
                _ => null
            };
        }
    }
}
