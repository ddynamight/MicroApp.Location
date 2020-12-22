using MediatR;
using MicroApp.Location.Domain.Events.Bicycles;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace MicroApp.Location.Application.Bicycles.Handlers.EventHandlers
{
     public class BicycleCreatedEventHandler : INotificationHandler<BicycleCreatedEvent>
     {
          private readonly ILogger<BicycleCreatedEventHandler> _logger;

          public BicycleCreatedEventHandler(ILogger<BicycleCreatedEventHandler> _logger)
          {
               this._logger = _logger;
          }

          public Task Handle(BicycleCreatedEvent notification, CancellationToken cancellationToken)
          {
               var domainEvent = notification.Bicycle.DomainEvents;

               _logger.LogInformation($"Bicycle Event: {domainEvent.GetType().Name} succeeded for Bicycle with Name: {notification.Bicycle.Name} and Id: {notification.Bicycle.Id}");

               return Task.CompletedTask;
          }
     }
}
