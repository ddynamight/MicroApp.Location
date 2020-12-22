using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroApp.Location.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroApp.Location.Persistence.Vehicles.Configurations
{
    public class VehicleEntityTypeConfiguration : IEntityTypeConfiguration<Vehicle>
    {
         public void Configure(EntityTypeBuilder<Vehicle> builder)
         {
              builder.ToTable("Vehicles");

              builder.HasKey(v => v.Id);
              builder.Ignore(v => v.DomainEvents);

              builder.Property(v => v.Latitude)
                   .HasColumnType("decimal(9,6)");

              builder.Property(v => v.Longitude)
                   .HasColumnType("decimal(12,9)");

               builder.Property(v => v.RowVersion)
                   .IsRowVersion();
         }
    }
}
