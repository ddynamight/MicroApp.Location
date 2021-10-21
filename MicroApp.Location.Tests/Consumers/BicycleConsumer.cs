using MicroApp.Location.Application.Bicycles.Models;
using Pactify;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Threading.Tasks;
using Xunit;

namespace MicroApp.Location.Tests.Consumers
{
     public class BicycleConsumer
     {
          [Fact]
          public async Task Consumer_Should_Create_A_Pack()
          {
               var options = new PactDefinitionOptions
               {
                    IgnoreContractValues = true,
                    IgnoreCasing = true
               };


               await PactMaker
                    .Create(options)
                    .Between("frontend", "bicycles")
                    .WithHttpInteraction(bc =>
                         bc.Given("There is a request for some id")
                              .UponReceiving("A GET request to get bicycle")
                              .With(request => request
                                   .WithMethod(HttpMethod.Get)
                                   .WithPath("/bicycles/1"))
                              .WillRespondWith(response => response
                                   .WithHeader("Content-Type", MediaTypeNames.Application.Json)
                                   .WithStatusCode(HttpStatusCode.OK)
                                   .WithBody<BicycleResponseModel>()))
                    .PublishedViaHttp("http://localhost:9292/pacts/provider/bicycles/consumer/frontend/version/1.0.0", HttpMethod.Put)
                    .MakeAsync();

          }
     }
}
