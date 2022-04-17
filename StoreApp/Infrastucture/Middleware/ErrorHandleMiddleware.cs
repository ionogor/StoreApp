using System.ComponentModel.DataAnnotations;
using System.Net;

namespace StoreApp.Infrastucture.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public ErrorHandlingMiddleware(RequestDelegate next, ILoggerFactory logger)
        {
            _next= next;
            _logger= logger.CreateLogger<ErrorDetails>();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var query = context.Request.Query["q"];

            try
            {
                if (query == "hi")
                {
                    await _next(context);
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);

                switch (ex)
                {
                    case ValidationException:
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    
                    case BadHttpRequestException:
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                   
                    default:
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                await CreateExceptionResponseAsync(context, ex);
            }


        }

        private Task CreateExceptionResponseAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            return context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message
            }.ToString());
        }
    }
}
