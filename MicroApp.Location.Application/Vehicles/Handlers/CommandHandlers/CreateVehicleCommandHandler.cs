using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MicroApp.Location.Application.Interfaces;
using MicroApp.Location.Application.Vehicles.Commands.CreateVehicle;
using MicroApp.Location.Domain.Events.Vehicles;
using MicroApp.Location.Domain.Vehicles;

namespace MicroApp.Location.Application.Vehicles.Handlers.CommandHandlers
{
     public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, int>
     {
          private readonly IAppDbContext _context;
          private readonly IMapper _mapper;

          public CreateVehicleCommandHandler(IAppDbContext _context, IMapper _mapper)
          {
               this._context = _context;
               this._mapper = _mapper;
          }

          public async Task<int> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
          {
               var vehicle = new Vehicle
               {
                    Name = request.Name,
                    RegNo = request.RegNo,
                    Latitude = request.Latitude,
                    Longitude = request.Longitude
               };

               vehicle.AddDomainEvent(new VehicleCreatedEvent(vehicle));

               _context.Vehicles.Add(vehicle);

               await _context.SaveChangesAsync(cancellationToken);


               return vehicle.Id;
          }
     }
}
