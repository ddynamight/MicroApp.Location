using MicroApp.Location.Domain.Bicycles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroApp.Location.Persistence.Bicycles.Configurations
{
     public class BicycleEntityTypeConfiguration : IEntityTypeConfiguration<Bicycle>
     {
          public void Configure(EntityTypeBuilder<Bicycle> builder)
          {
               builder.ToTable("Bicycles");

               builder.HasKey(b => b.Id);
               builder.Ignore(b => b.DomainEvents);

               builder.Property(b => b.Latitude)
                    .HasColumnType("decimal(9,6)");

               builder.Property(b => b.Longitude)
                    .HasColumnType("decimal(12,9)");

               builder.Property(b => b.RowVersion)
                    .IsRowVersion();
          }
     }
}
