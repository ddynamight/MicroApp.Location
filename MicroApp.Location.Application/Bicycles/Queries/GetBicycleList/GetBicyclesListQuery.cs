using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MicroApp.Location.Application.Bicycles.Models;

namespace MicroApp.Location.Application.Bicycles.Queries.GetBicycleList
{
     public class GetBicyclesListQuery : IRequest<List<BicycleResponseModel>>
     {
     }
}
