using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroApp.Location.Application.Bicycles.Commands.CreatBicycle
{
    public interface ICreateBicycleCommand
    {
         void Execute(CreateBicycleModel model);
    }
}
