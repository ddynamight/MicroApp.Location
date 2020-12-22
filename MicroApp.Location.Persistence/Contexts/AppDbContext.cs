using MicroApp.Location.Application.Interfaces;
using MicroApp.Location.Domain.Bicycles;
using MicroApp.Location.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MicroApp.Location.Domain.Vehicles;

namespace MicroApp.Location.Persistence.Contexts
{
     public class AppDbContext : DbContext, IAppDbContext
     {
          public AppDbContext()
          {
          }

          public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
          {
          }

          public static AppDbContext Create()
          {
               return new AppDbContext();
          }

          public virtual DbSet<Bicycle> Bicycles { get; set; }
          public virtual DbSet<Vehicle> Vehicles { get; set; }

          
          public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
          {
               /*
               foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
               {
                    switch (entry.State)
                    {
                         case EntityState.Added:
                              entry.Entity.CreatedBy = _currentUserService.UserId;
                              entry.Entity.Created = _dateTime.Now;
                              break;

                         case EntityState.Modified:
                              entry.Entity.LastModifiedBy = _currentUserService.UserId;
                              entry.Entity.LastModified = _dateTime.Now;
                              break;
                    }
               }
               */

               
               var result = await base.SaveChangesAsync(cancellationToken);

               //await DispatchEvents();

               return result;
          }
          

          protected override void OnModelCreating(ModelBuilder modelBuilder)
          {
               modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

               base.OnModelCreating(modelBuilder);
          }

          protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          {
               var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
               IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                    .AddJsonFile("appsettings.json", optional: true)
                    .AddJsonFile($"appsettings.{envName}.json", optional: true)
                    .Build();
               optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
          }

          /*
          private async Task DispatchEvents()
          {
               var domainEventEntities = ChangeTracker.Entries<IHasDomainEvent>()
                    .Select(x => x.Entity.DomainEvents)
                    .SelectMany(x => x)
                    .Where(domainEvent => !domainEvent.IsPublished);

               foreach (var domainEvent in domainEventEntities)
               {
                    domainEvent.IsPublished = true;
                    await _domainEventService.Publish(domainEvent);
               }
          }
          */
     }
}
