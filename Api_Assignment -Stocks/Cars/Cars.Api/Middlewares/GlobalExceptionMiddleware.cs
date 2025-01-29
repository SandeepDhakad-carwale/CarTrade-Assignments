
using System.Net;

namespace Cars.Api.Middlewares{
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
           
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            
           // _logger.LogError(ex, "An unhandled exception occurred.");

          
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        var response = new
        {
            message = exception.Message,
            details = "An unexpected error occurred. Please try again later.",
            status = (int)HttpStatusCode.InternalServerError 
        };

        switch (exception)
        {
            case ArgumentException:
                response = new
                {
                    message = exception.Message,
                    details = "Invalid input provided.",
                    status = (int)HttpStatusCode.BadRequest // 400 Bad Request
                };
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                break;

            case KeyNotFoundException:
                response = new
                {
                    message = exception.Message,
                    details = "The requested resource was not found.",
                    status = (int)HttpStatusCode.NotFound // 404 Not Found
                };
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                break;

            default:
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                break;
        }

        return context.Response.WriteAsJsonAsync(response);
    }
}

}