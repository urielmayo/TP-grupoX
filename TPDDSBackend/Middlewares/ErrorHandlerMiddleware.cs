using System.Net;
using System.Text.Json;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TPDDSBackend.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new CustomResponse<string>(false, e.Message);
                switch (e)
                {
                    case ApiCustomException ex:
                        response.StatusCode = (int)ex.statusCode;
                        responseModel.Errors = new List<string>() { ex.Message };
                        break;
                    case ValidationPasswordException ex:
                        response.StatusCode = (int)ex.statusCode;
                        responseModel.Errors = ex.Errors;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}
