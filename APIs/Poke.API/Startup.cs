using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Poke.API.Middleware;
using Poke.API.Models;
using System;
using System.Net;

namespace Poke.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(opt =>
                {
                    opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    opt.SerializerSettings.Converters.Add(new StringEnumConverter()); //------------------------>
                });
            // ConnectionString

            services.AddDependency();



            services.AddSwaggerGen();
            services.AddSwaggerGenNewtonsoftSupport();//------------------------>
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            else
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
                            //await context.Response.WriteAsync(ex.Error.Message); //using Microsoft.AspNetCore.Http;
                            //=============================================
                            await context.Response.WriteAsync(new ErrorDetail
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = "Internal server error"
                            }.ToString());
                            //=============================================
                            if (ex.Error is NullReferenceException)
                            {

                            }
                            string a = "";

                            bool isA = false;
                            switch (a)
                            {
                                case "a":
                                    isA = true;
                                    break;
                                case "b":
                                    isA = true;
                                    break;
                                default:
                                    break;
                            }
                            Console.WriteLine("okokok");
                            //catch (HttpException ex) when (ex.WebEventCode >= 500)
                            //switch (ex.Error)
                            //{
                            //    case ex.Error is NullReferenceException:
                            //        Console.WriteLine("asdasd");
                            //        break;
                            //    default:
                            //        break;
                            //}
                        }

                    });
                });
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}