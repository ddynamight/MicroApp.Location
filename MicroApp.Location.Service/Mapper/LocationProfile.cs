using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroApp.Location.Application.Bicycles.Models;
using MicroApp.Location.Domain.Bicycles;

namespace MicroApp.Location.Service.Mapper
{
     public class LocationProfile : Profile
     {
          public LocationProfile()
          {
               AllowNullCollections = true;
               AllowNullDestinationValues = true;

               CreateMap<Bicycle, BicycleResponseModel>();
          }
     }
}
