using DevJJGR.Exceptions;
using DevJJGRCore.Common.Models;
using System.Net;
using System.Text.Json;

namespace DevJJGR.Middlewares
{
    public class ErrorEventHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorEventHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new ResponseDto<string>();
                responseModel.SetMessage(ex.Message);
                switch (ex)
                {
                    case ValidationException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.SetStatusCode(StatusCode.BAD_REQUEST);
                        responseModel.SetErrors(e.Errors);
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

