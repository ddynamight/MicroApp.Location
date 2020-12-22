using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroApp.Location.Application.Bicycles.Commands.CreatBicycle
{
    public class CreateBicycleModel
    {
         public string Name { get; set; }
         public string Type { get; set; }
         public decimal Latitude { get; set; }
         public decimal Longitude { get; set; }
     }
}
