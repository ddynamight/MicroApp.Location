using MicroApp.Location.Application.Bicycles.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace MicroApp.Location.Tests
{
     public class StartUp
     {
          public void ConfigureServices(IServiceCollection services)
          {
               services.AddRouting();
          }

          public void Configure(IApplicationBuilder app)
          {
               app.UseRouter(builder =>
               {
                    builder.MapGet($"/bicycles/1", async (request, response, data) =>
                    {
                         var bicycle = new BicycleResponseModel() { Id = 1, Name = "Some Bicycle", Latitude = 10.000m, Longitude = 12.000m, Type = "Shopper" };
                         var json = JsonConvert.SerializeObject(bicycle);
                         await response.WriteAsync(json);
                    });
               });
          }
     }
}
