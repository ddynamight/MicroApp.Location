using MicroApp.Location.Application.Bicycles.Models;

namespace MicroApp.Location.Application.Bicycles.Queries.GetBicycle
{
     public interface IGetBicycleQuery
     {
          BicycleResponseModel Execute();
     }
}
