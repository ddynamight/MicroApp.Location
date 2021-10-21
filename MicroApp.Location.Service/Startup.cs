using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MicroApp.Location.Application.Bicycles.Commands.CreatBicycle;
using MicroApp.Location.Application.Bicycles.Handlers.CommandHandlers;
using MicroApp.Location.Application.Bicycles.Handlers.QueryHandlers;
using MicroApp.Location.Application.Bicycles.Models;
using MicroApp.Location.Application.Bicycles.Queries.GetBicycle;
using MicroApp.Location.Application.Bicycles.Queries.GetBicycleList;
using MicroApp.Location.Application.Interfaces;
using MicroApp.Location.Persistence.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MicroApp.Location.Service
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

               services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


               services.AddHealthChecks();
               services.AddControllers()
                    .AddNewtonsoftJson(options =>
                    {
                         options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                         options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                         options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
                    });

               services.AddSwaggerGen(c =>
               {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                         Version = "v1",
                         Title = "MicroApp API",
                         Description = "This is the MicroApp API",
                         TermsOfService = new Uri("https://wwww.microapp.com/terms-of-service"),
                         License = new OpenApiLicense
                         {
                              Name = "MicroApp License",
                              Url = new Uri("https://www.microapp.com/license")
                         },
                         Contact = new OpenApiContact
                         {
                              Email = "ismail@ismailumar.com",
                              Name = "Ismail Umar",
                              Url = new Uri("https://www.ismailumar.com"),
                         },
                    });

                    // Set the comments path for the Swagger JSON and UI.
                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    c.IncludeXmlComments(xmlPath, true);
               });

               services.Configure<ApiBehaviorOptions>(options =>
               {
                    options.SuppressConsumesConstraintForFormFileParameters = false;
                    options.SuppressInferBindingSourcesForParameters = false;
                    options.SuppressModelStateInvalidFilter = false;
               });

               services.AddLogging(logging =>
               {
                    logging.AddConsole();
                    logging.AddDebug();
               });

               services.AddAutoMapper(typeof(Startup));

               services.AddScoped<IAppDbContext, AppDbContext>();

               services.AddScoped<IRequestHandler<CreateBicycleCommand, int>, CreateBicycleCommandHandler>();
               services.AddScoped<IRequestHandler<GetBicycleQuery, BicycleResponseModel>, GetBicycleQueryHandler>();
               services.AddScoped<IRequestHandler<GetBicyclesListQuery, List<BicycleResponseModel>>, GetBicyclesListQueryHandler>();

               //services.AddMediatR(Assembly.GetExecutingAssembly());
               services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
          }

          // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
          public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
          {
               if (env.IsDevelopment())
               {
                    app.UseDeveloperExceptionPage();
               }
               else
               {
                    app.UseExceptionHandler(appBuilder =>
                    {
                         appBuilder.Run(async context =>
                         {
                              var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                              if (exceptionHandlerFeature != null)
                              {
                                   var logger = loggerFactory.CreateLogger("Global exception logger");
                                   logger.LogError(500,
                                        exceptionHandlerFeature.Error,
                                        exceptionHandlerFeature.Error.Message);
                              }
                              context.Response.StatusCode = 500;
                              await context.Response.WriteAsync("An unexpected fault happened. Try again later.").ConfigureAwait(false);
                         });
                    });
               }


               app.UseSwagger();
               app.UseSwaggerUI(c =>
               {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MicroApp API V1");
                    c.RoutePrefix = string.Empty;
               });


               app.UseHealthChecks("/health");
               app.UseHttpsRedirection();

               app.UseRouting();

               app.UseAuthorization();

               app.UseEndpoints(endpoints =>
               {
                    endpoints.MapControllers();
               });
          }
     }
}
