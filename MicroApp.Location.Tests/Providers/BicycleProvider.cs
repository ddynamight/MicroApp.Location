using MicroApp.Location.Service;
using Pactify;
using System.Threading.Tasks;
using Xunit;

namespace MicroApp.Location.Tests.Providers
{
     public class BicycleProvider
     {
          [Fact]
          public async Task Provider_Should_Meet_Consumers_Expectations()
          {
               //Todo: Use the API Startup class

               await PactVerifier
                    .CreateFor<StartUp>()
                    .Between("frontend", "bicycles")
                    .RetrievedViaHttp($"http://localhost:9292/pacts/provider/bicycles/consumer/frontend/latest")
                    .VerifyAsync();
          }
     }
}
