using AutoMapper;
using MediatR;
using MicroApp.Location.Application.Bicycles.Models;
using MicroApp.Location.Application.Bicycles.Queries.GetBicycleList;
using MicroApp.Location.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MicroApp.Location.Application.Bicycles.Handlers.QueryHandlers
{
     public class GetBicyclesListQueryHandler : IRequestHandler<GetBicyclesListQuery, List<BicycleResponseModel>>
     {
          private readonly IAppDbContext _context;
          private readonly IMapper _mapper;

          public GetBicyclesListQueryHandler(IAppDbContext _context, IMapper _mapper)
          {
               this._context = _context;
               this._mapper = _mapper;
          }

          public async Task<List<BicycleResponseModel>> Handle(GetBicyclesListQuery request, CancellationToken cancellationToken)
          {
               var bicyclesFromDb = await _context.Bicycles.ToListAsync(cancellationToken);

               return _mapper.Map<List<BicycleResponseModel>>(bicyclesFromDb);
          }
     }
}
