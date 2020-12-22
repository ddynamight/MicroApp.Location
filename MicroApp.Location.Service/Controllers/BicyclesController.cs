using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MicroApp.Location.Application.Bicycles.Commands.CreatBicycle;
using MicroApp.Location.Application.Bicycles.Models;
using MicroApp.Location.Application.Bicycles.Queries.GetBicycle;
using MicroApp.Location.Application.Bicycles.Queries.GetBicycleList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroApp.Location.Service.Controllers
{
     /// <summary>
     /// Bicycles: Provides the bicycles information
     /// </summary>
     [Route("[controller]"), ApiController]
     public class BicyclesController : Controller
     {
          private readonly IMediator mediator;

          public BicyclesController(IMediator mediator)
          {
               this.mediator = mediator;
          }


          /// <summary>
          /// gets a list of bicycles from the repository
          /// </summary>
          /// <returns>gets a list of Bicycle Models</returns>
          [HttpGet, ProducesResponseType(typeof(List<BicycleResponseModel>), StatusCodes.Status200OK), ]
          public async Task<IActionResult> GetBicyclesAsync()
          {
               var bicycles = await mediator.Send(new GetBicyclesListQuery());

               return Ok(bicycles);
          }

          [HttpGet("{id}", Name = "GetBicycle"), ProducesResponseType(typeof(BicycleResponseModel), StatusCodes.Status200OK), ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
          public async Task<IActionResult> GetBicycle(int id)
          {
               var bicycle = await mediator.Send(new GetBicycleQuery
               {
                    Id = id
               });
               if (bicycle is null)
               {
                    return BadRequest($"Bicycle with ID: {id} cannot be found");
               }
               return Ok(bicycle);
          }

          [HttpPost]
          public async Task<IActionResult> CreateBicycle(CreateBicycleCommand command)
          {
               var result = await mediator.Send(command);

               if (result == 0)
               {
                    return BadRequest($"Bicycle with Name: {command.Name}, could not be created");
               }

               var bicycle = new BicycleResponseModel
               {
                    Id = result,
                    Name = command.Name,
                    Type = command.Type,
                    Latitude = command.Latitude,
                    Longitude = command.Longitude
               };

               return CreatedAtRoute(nameof(GetBicycle), new { id = bicycle.Id}, bicycle);
          }
     }
}
