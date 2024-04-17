using App.Comon.Exceptions;
using Infastructure.Comons.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace Is4App.Middleware
{
    public class CustomExceptionsHandlerMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate next = next;
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            string message = string.Empty;

            switch (exception) 
            {
                case UserNotFoundException userNotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    message = JsonSerializer.Serialize(userNotFoundException.Message);
                    break;
                case PasswordWrongException passwordWrongException:
                    statusCode = HttpStatusCode.BadRequest;
                    message = JsonSerializer.Serialize(passwordWrongException.Message);
                    break;
                case AccessDeniedException accessDeniedException:
                    statusCode = HttpStatusCode.Forbidden;
                    message = JsonSerializer.Serialize(accessDeniedException.Message);
                    break;
                case CustomValidationException validationException:
                    statusCode = HttpStatusCode.BadRequest;
                    message = JsonSerializer.Serialize(validationException.Message);
                    break;
            }

            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";

            if(message == string.Empty)
                message = JsonSerializer.Serialize(new { error = exception.Message });

            return context.Response.WriteAsync(message);
        }
    }
}
