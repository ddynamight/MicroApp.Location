using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MicroApp.Location.Application.Bicycles.Commands.CreatBicycle
{
     public class CreateBicycleCommand : IRequest<int>
     {
          public string Name { get; set; }
          public string Type { get; set; }
          public decimal Latitude { get; set; }
          public decimal Longitude { get; set; }
     }
}
