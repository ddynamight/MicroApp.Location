using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MicroApp.Location.Application.Bicycles.Models;
using Newtonsoft.Json;

namespace MicroApp.Location.Tests.Consumers.Clients
{
     public class BicycleApiClient
     {
          private readonly HttpClient _client;

          public BicycleApiClient(string baseuri = null)
          {
               _client = new HttpClient { BaseAddress = new Uri(baseuri ?? "http//localhost:8888")};
          }

          public async Task<BicycleResponseModel> GetBicycle(int id)
          {
               string reasonPhrase;

               var request = new HttpRequestMessage(HttpMethod.Get, "/bicycles/" + id);
               request.Headers.Add("Accept", "application/json");

               var response = await _client.SendAsync(request);

               var content = await response.Content.ReadAsStringAsync();
               var status = response.StatusCode;

               reasonPhrase = response.ReasonPhrase; //NOTE: any Pact mock provider errors will be returned here and in the response body

               request.Dispose();
               response.Dispose();

               if (status == HttpStatusCode.OK)
               {
                    return !String.IsNullOrEmpty(content) ?
                         JsonConvert.DeserializeObject<BicycleResponseModel>(content)
                         : null;
               }

               throw new Exception(reasonPhrase);
          }
     }
}
