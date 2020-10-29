using System;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BasicEssentials
{
    public static class FilterExceptions
    {
        public static void ConfigureHandlerExceptions(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>(); // Microsoft.AspNetCore.Diagnostics;
                    if (contextFeature != null)
                    {
                        if (contextFeature.Error is NotImplementedException)
                        {
                            var exception = (NotImplementedException) contextFeature.Error;
                            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                            var respondeModel = new
                            {
                                exception.Message,
                                exception.StackTrace
                            };
                            await context.Response.WriteAsync(JsonConvert.SerializeObject(respondeModel));
                            return;
                        }
                    }

                });
            });
        }
    }
}

//Microsoft.AspNetCore.Diagnostics