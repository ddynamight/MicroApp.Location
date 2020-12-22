using AutoMapper;
using MediatR;
using MicroApp.Location.Application.Bicycles.Models;
using MicroApp.Location.Application.Bicycles.Queries.GetBicycle;
using MicroApp.Location.Application.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MicroApp.Location.Application.Bicycles.Handlers.QueryHandlers
{
     public class GetBicycleQueryHandler : IRequestHandler<GetBicycleQuery, BicycleResponseModel>
     {
          private readonly IAppDbContext _context;
          private readonly IMapper _mapper;

          public GetBicycleQueryHandler(IAppDbContext _context, IMapper _mapper)
          {
               this._context = _context;
               this._mapper = _mapper;
          }

          public async Task<BicycleResponseModel> Handle(GetBicycleQuery request, CancellationToken cancellationToken)
          {
               var bicycleFromDb = await _context.Bicycles.SingleAsync(e => e.Id.Equals(request.Id), cancellationToken);

               return _mapper.Map<BicycleResponseModel>(bicycleFromDb);
          }
     }
}
