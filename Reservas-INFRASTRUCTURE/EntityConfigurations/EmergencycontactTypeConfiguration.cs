using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservas_DOMAIN.AggregateModels.EmergencycontactAggregate;
using Reservas_DOMAIN.SeedWork;


namespace Reservas_INFRASTRUCTURE.EntityConfigurations
{
    internal class EmergencycontactTypeConfiguration: IEntityTypeConfiguration<Emergencycontact>
    {
        public void Configure(EntityTypeBuilder<Emergencycontact> builder)
        {

            builder.HasKey(e => e.Id).HasName("emergencycontacts_pkey");

            builder.ToTable("emergencycontacts");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.ContactPhone)
                .HasMaxLength(100)
                .HasColumnName("contact_phone");
            builder.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
            builder.Property(e => e.ReservationId).HasColumnName("reservation_id");

            builder.HasOne(d => d.Reservation).WithMany(p => p.Emergencycontacts)
                .HasForeignKey(d => d.ReservationId)
                .HasConstraintName("emergencycontacts_reservation_id_fkey");
        }

    }
}
