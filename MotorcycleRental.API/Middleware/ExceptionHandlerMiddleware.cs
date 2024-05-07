using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Net.Mime;
using System.Reflection.Metadata.Ecma335;

namespace MotorcycleRental.API.Middleware
{
    public static class ExceptionHandlerMiddleware
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = MediaTypeNames.Application.Json;

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new UnexpectedErrorDto(
                            context.Response.StatusCode,
                            contextFeature.Error.Message,
                            contextFeature.Error.StackTrace
                        ).ToString());
                    }
                });
            });
        }
    }
    public record UnexpectedErrorDto(int StatusCode,string Message,string trace)
    {
        public override string ToString() =>
            System.Text.Json.JsonSerializer.Serialize<UnexpectedErrorDto>(this);
    }
}
