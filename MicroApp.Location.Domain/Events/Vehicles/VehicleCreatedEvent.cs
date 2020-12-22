using MediatR;
using MicroApp.Location.Domain.Vehicles;

namespace MicroApp.Location.Domain.Events.Vehicles
{
     public class VehicleCreatedEvent : INotification
    {
         public VehicleCreatedEvent(Vehicle vehicle)
         {
              Vehicle = vehicle;
         }

         public Vehicle Vehicle { get; }
    }
}
