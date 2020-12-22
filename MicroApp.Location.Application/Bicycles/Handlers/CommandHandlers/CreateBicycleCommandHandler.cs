using AutoMapper;
using MediatR;
using MicroApp.Location.Application.Bicycles.Commands.CreatBicycle;
using MicroApp.Location.Application.Interfaces;
using MicroApp.Location.Domain.Bicycles;
using MicroApp.Location.Domain.Events.Bicycles;
using System.Threading;
using System.Threading.Tasks;

namespace MicroApp.Location.Application.Bicycles.Handlers.CommandHandlers
{
     public class CreateBicycleCommandHandler : IRequestHandler<CreateBicycleCommand, int>
     {
          private readonly IAppDbContext _context;
          private readonly IMapper _mapper;

          public CreateBicycleCommandHandler(IAppDbContext _context, IMapper _mapper)
          {
               this._context = _context;
               this._mapper = _mapper;
          }

          public async Task<int> Handle(CreateBicycleCommand request, CancellationToken cancellationToken)
          {
               var bicycle = new Bicycle
               {
                    Name =  request.Name,
                    Type =  request.Type,
                    Latitude = request.Latitude,
                    Longitude = request.Longitude
               };

               bicycle.AddDomainEvent(new BicycleCreatedEvent(bicycle));

               
               _context.Bicycles.Add(bicycle);


               await _context.SaveChangesAsync(cancellationToken);


               return bicycle.Id;
          }
     }
}
