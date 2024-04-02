using Application.Common.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Net;
using System.Text.Json;

namespace WebApi.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;
        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
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

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            string result = string.Empty;

            switch (exception)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.Errors);
                    break;
                case OrderNotFoundException orderException:
                    code = HttpStatusCode.NotFound;
                    break;
            }

            context.Response.StatusCode = (int)code;
            context.Response.ContentType = "application/json";

            if(result == string.Empty)
                result = JsonSerializer.Serialize(new { error = exception.Message });

            return context.Response.WriteAsync(result);
        }
    }
}
