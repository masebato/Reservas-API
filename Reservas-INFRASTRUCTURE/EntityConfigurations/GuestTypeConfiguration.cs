using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservas_DOMAIN.AggregateModels.GuestAggregate;
using Reservas_DOMAIN.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas_INFRASTRUCTURE.EntityConfigurations
{
    internal class GuestTypeConfiguration : IEntityTypeConfiguration<Guest>
    {

        public void Configure(EntityTypeBuilder<Guest> builder)
        {

            builder.HasKey(e => e.Id).HasName("guests_pkey");

            builder.ToTable("guests");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.ContactPhone)
                .HasMaxLength(100)
                .HasColumnName("contact_phone");
            builder.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            builder.Property(e => e.DocumentNumber)
                .HasMaxLength(100)
                .HasColumnName("document_number");
            builder.Property(e => e.DocumentType)
                .HasMaxLength(50)
                .HasColumnName("document_type");
            builder.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            builder.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            builder.Property(e => e.Gender)
                .HasMaxLength(50)
                .HasColumnName("gender");
            builder.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
            builder.Property(e => e.ReservationId).HasColumnName("reservation_id");

            builder.HasOne(d => d.Reservation).WithMany(p => p.Guests)
                .HasForeignKey(d => d.ReservationId)
                .HasConstraintName("guests_reservation_id_fkey");


        }
    }
}
