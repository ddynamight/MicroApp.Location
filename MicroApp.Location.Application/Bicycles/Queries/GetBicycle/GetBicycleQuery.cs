using MediatR;
using MicroApp.Location.Application.Bicycles.Models;

namespace MicroApp.Location.Application.Bicycles.Queries.GetBicycle
{
     public class GetBicycleQuery : IRequest<BicycleResponseModel>
     {
          public int Id { get; set; }
     }
}
