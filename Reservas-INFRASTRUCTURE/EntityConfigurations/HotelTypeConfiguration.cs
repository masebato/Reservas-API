using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservas_DOMAIN.AggregateModels.HotelAggregate;
using Reservas_DOMAIN.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Reservas_INFRASTRUCTURE.EntityConfigurations
{
    internal class HotelTypeConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {

            builder.HasKey(e => e.Id).HasName("hotels_pkey");
            builder.ToTable("hotels");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Address).HasColumnName("address");
            builder.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            builder.Property(e => e.Description).HasColumnName("description");
            builder.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            builder.Property(e => e.Rating).HasColumnName("rating");
            builder.Property(e => e.Status).HasColumnName("status");


        }

    }
}
