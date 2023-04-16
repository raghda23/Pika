using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Pikia.APIs.Errors;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pikia.APIs.Middelware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;
        private readonly IHostEnvironment env;

        public ExceptionMiddleware(RequestDelegate _next , ILogger<ExceptionMiddleware> _logger ,IHostEnvironment _env)
        {
            next = _next;
            logger = _logger;
            env = _env;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
               logger.LogError(ex , ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                var exceptionErrorResponse = env.IsDevelopment() ?
                     new ApiExceptionResponse(500, ex.Message, ex.StackTrace.ToString())
                     :
                     new ApiExceptionResponse(500);

                var options = new JsonSerializerOptions() {PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
                var json = JsonSerializer.Serialize(exceptionErrorResponse , options);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
