using System.Threading;
using System.Threading.Tasks;
using MicroApp.Location.Domain.Bicycles;
using MicroApp.Location.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace MicroApp.Location.Application.Interfaces
{
     public interface IAppDbContext
     {
          DbSet<Bicycle> Bicycles { get; set; }
          DbSet<Vehicle> Vehicles { get; set; }
          Task<int> SaveChangesAsync(CancellationToken cancellationToken);
     }
}
