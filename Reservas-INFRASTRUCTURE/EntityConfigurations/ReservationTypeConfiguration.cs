using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservas_DOMAIN.AggregateModels.ReservationAggregate;
using Reservas_DOMAIN.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas_INFRASTRUCTURE.EntityConfigurations
{
    internal class ReservationTypeConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(e => e.Id).HasName("reservations_pkey");

            builder.ToTable("reservations");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.CheckInDate).HasColumnName("check_in_date");
            builder.Property(e => e.CheckOutDate).HasColumnName("check_out_date");
            builder.Property(e => e.NumberOfGuests).HasColumnName("number_of_guests");
            builder.Property(e => e.RoomId).HasColumnName("room_id");
            builder.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            builder.Property(e => e.TotalCost)
                .HasPrecision(10, 2)
                .HasColumnName("total_cost");
            builder.Property(e => e.UserId).HasColumnName("user_id");

            builder.HasOne(d => d.Room).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("reservations_room_id_fkey");

            builder.HasOne(d => d.User).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("reservations_user_id_fkey");
        }
    }
}
