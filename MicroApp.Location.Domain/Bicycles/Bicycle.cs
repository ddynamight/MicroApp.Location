using System.Collections.Generic;
using MicroApp.Location.Domain.Common;

namespace MicroApp.Location.Domain.Bicycles
{
     public class Bicycle : Entity, IHasDomainEvent
     {
          public string Name { get; set; }
          public string Type { get; set; }
          public decimal Latitude { get; set; }
          public decimal Longitude { get; set; }
          public byte[] RowVersion { get; set; }

          
          public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
     }
}
