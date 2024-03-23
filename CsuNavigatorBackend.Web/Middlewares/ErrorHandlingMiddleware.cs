using System.Net.Mime;
using System.Text.Json;
using CsuNavigatorBackend.Domain.Errors;
using CsuNavigatorBackend.Web.Exceptions;
using CsuNavigatorBackend.Web.Models;

namespace CsuNavigatorBackend.Web.Middlewares;

public class ErrorHandlingMiddleware(
    ILogger<ErrorHandlingMiddleware> logger
) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (Exception ex)
        {
            string newContent;
            ServerErrorModel errorModel;
            switch (ex)
            {
                case ExceptionBase customExceptionBase:
                    context.Response.StatusCode = customExceptionBase.StatusCode;
                    errorModel = new ServerErrorModel(customExceptionBase.Error);
                    logger.LogError($"{errorModel.Error.Code}:{errorModel.Error.Description}");
                    newContent = JsonSerializer.Serialize(errorModel);
                    break;
                default:
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    errorModel = new ServerErrorModel(
                        new Error(ex.GetType().ToString(), ex.Message));
                    logger.LogError($"{errorModel.Error.Code}:{errorModel.Error.Description}");
                    newContent = JsonSerializer.Serialize(errorModel);
                    break;
            }

            context.Response.ContentType = MediaTypeNames.Application.Json;
            await context.Response.WriteAsync(newContent);
        }
    }
}