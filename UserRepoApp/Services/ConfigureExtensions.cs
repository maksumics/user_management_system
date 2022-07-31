using Microsoft.AspNetCore.Diagnostics;
using Serilog;
using UserRepoApp.Models;

namespace UserRepoApp.Services
{
    public static class ConfigureExtensions
    {
        public static void ConfigureGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        Log.Error($"There was a problem, {contextFeature.Error}");

                        await context.Response.WriteAsync(new ErrorModel()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal server error occured!"
                        }.ToString()); ;
                    }
                });
            });
        }
    }
}
