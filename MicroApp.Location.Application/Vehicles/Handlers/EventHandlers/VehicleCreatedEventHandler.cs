using MediatR;
using MicroApp.Location.Domain.Events.Vehicles;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace MicroApp.Location.Application.Vehicles.Handlers.EventHandlers
{
     public class VehicleCreatedEventHandler : INotificationHandler<VehicleCreatedEvent>
     {
          private readonly ILogger<VehicleCreatedEventHandler> _logger;

          public VehicleCreatedEventHandler(ILogger<VehicleCreatedEventHandler> _logger)
          {
               this._logger = _logger;
          }

          public Task Handle(VehicleCreatedEvent notification, CancellationToken cancellationToken)
          {
               var domainEvent = notification.Vehicle.DomainEvents;

               _logger.LogInformation($"Vehicle Event: {domainEvent.GetType().Name} succeeded for Vehicle with Name: {notification.Vehicle.Name} and Id: {notification.Vehicle.Id}");

               return Task.CompletedTask;
          }
     }
}
