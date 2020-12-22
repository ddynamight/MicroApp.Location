using MediatR;
using MicroApp.Location.Domain.Bicycles;

namespace MicroApp.Location.Domain.Events.Bicycles
{
     public class BicycleCreatedEvent : INotification
     {
          public BicycleCreatedEvent(Bicycle bicycle)
          {
               Bicycle = bicycle;
          }

          public Bicycle Bicycle { get; }
     }
}
