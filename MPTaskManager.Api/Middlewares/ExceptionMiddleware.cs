using System.Net;
using MPTaskManager.Api.Utils.Exceptions;
using Newtonsoft.Json;
namespace MPTaskManager.Api.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    
    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    
    // Middleware to handle exceptions 
    public async Task InvokeAsync(HttpContext httpContext)
    {
        // Try to execute the next middleware 
        try
        {
            await _next(httpContext);
        }
        catch (BadRequestException ex)
        {
            // Handle the exception if it is a BadRequestException
            _logger.LogError(ex, "Bad request");
            await HandleExceptionAsync(httpContext, ex, HttpStatusCode.BadRequest);
        }
        catch (NotFoundException ex)
        {
            // Handle the exception if it is a NotFoundException
            _logger.LogError(ex, "Resource not found");
            await HandleExceptionAsync(httpContext, ex, HttpStatusCode.NotFound);
        }
        catch (Exception ex)
        {
            // Handle any other exception
            _logger.LogError(ex, "Unhandled exception");
            await HandleExceptionAsync(httpContext, ex, HttpStatusCode.InternalServerError);
        }
    }
    
    // Method to handle exceptions and return a JSON response
    private static Task HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode statusCode)
    {
        // Log the exception
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;
        
        var response = new { message = exception.Message };
        return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
    }
}