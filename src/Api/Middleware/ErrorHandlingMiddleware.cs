using Api.Helpers;
using FluentValidation;
using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        private readonly JsonSerializerOptions _jsonoption;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
            _jsonoption = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(IsReturnedException e)
            {
                var statusCode = 404;

                context.Response.StatusCode = statusCode;

                var response = JsonSerializer.Serialize(new ErrorResponse(statusCode, e.Message), _jsonoption);

                await context.Response.WriteAsync(response);
            }
            catch(ValidationException e)
            {

                var statusCode = 400;

                context.Response.StatusCode = statusCode;

                var response = JsonSerializer.Serialize(new ValidationErrorResponse(400, e), _jsonoption) ;

                await context.Response.WriteAsync(response);
            }
            catch(NotFoundException e)
            {
                var statusCode = 404;

                context.Response.StatusCode = statusCode;

                var response = JsonSerializer.Serialize(new ErrorResponse(statusCode, e.Message), _jsonoption);

                await context.Response.WriteAsync(response);
            }
            catch(ItemExistsException e)
            {
                var statusCode = 409;

                context.Response.StatusCode = statusCode;

                var response = JsonSerializer.Serialize(new ErrorResponse(statusCode, e.Message), _jsonoption);

                await context.Response.WriteAsync(response);
            }
            catch(Exception e)
            {
                var statusCode = 500;

                context.Response.StatusCode = statusCode;

                var response = JsonSerializer.Serialize(new ErrorResponse(statusCode, e.Message), _jsonoption);

                await context.Response.WriteAsync(response);
            }
        }
    }
}
