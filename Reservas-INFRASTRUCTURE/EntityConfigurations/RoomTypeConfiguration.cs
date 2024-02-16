using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservas_DOMAIN.AggregateModels.RoomAggregate;
using Reservas_DOMAIN.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas_INFRASTRUCTURE.EntityConfigurations
{
    internal class RoomTypeConfiguration : IEntityTypeConfiguration<Room>
    {

        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(e => e.Id).HasName("rooms_pkey");

            builder.ToTable("rooms");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.BaseCost)
                .HasPrecision(10, 2)
                .HasColumnName("base_cost");
            builder.Property(e => e.HotelId).HasColumnName("hotel_id");
            builder.Property(e => e.Location)
                .HasMaxLength(255)
                .HasColumnName("location");
            builder.Property(e => e.Number)
                .HasMaxLength(50)
                .HasColumnName("number");
            builder.Property(e => e.Status).HasColumnName("status");
            builder.Property(e => e.Taxes)
                .HasPrecision(10, 2)
                .HasColumnName("taxes");
            builder.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");

            builder.HasOne(d => d.Hotel).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.HotelId)
                .HasConstraintName("rooms_hotel_id_fkey");

        }
    }
}
