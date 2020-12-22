using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroApp.Location.Application.Bicycles.Models;

namespace MicroApp.Location.Application.Bicycles.Queries.GetBicycleList
{
    public interface IGetBicyclesListQuery
    {
         List<BicycleResponseModel> Execute();
    }
}
