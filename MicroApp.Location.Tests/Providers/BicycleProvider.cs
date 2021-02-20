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
              await PactVerifier
                   .CreateFor<StartUp>()
                   .Between("frontend", "bicycles")
                   .RetrievedViaHttp("https://localhost/pacts/provider/bicycles/consumer/frontend/version/1.0.0")
                   .VerifyAsync();
         }
     }
}
