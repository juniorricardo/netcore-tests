using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

using System.Net;

namespace Poke.API.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigurationExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(app =>
            {
                app.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; //using System.Net;
                    context.Response.ContentType = "application/json";

                    var ex = context.Features.Get<IExceptionHandlerFeature>(); // using Microsoft.AspNetCore.Diagnostics;

                    if (ex != null)
                    {
                        await context.Response.WriteAsync(ex.Error.Message); //using Microsoft.AspNetCore.Http;
                    }

                });
            });
        }
    }
}
