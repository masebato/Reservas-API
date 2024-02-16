using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservas_DOMAIN.AggregateModels.UserAggregate;
using Reservas_DOMAIN.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas_INFRASTRUCTURE.EntityConfigurations
{
    internal class UserTypeConfiguration : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(e => e.Id).HasName("users_pkey");

            builder.ToTable("users");

            builder.HasIndex(e => e.Email, "users_email_key").IsUnique();

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            builder.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            builder.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            builder.Property(e => e.Role)
                .HasMaxLength(50)
                .HasColumnName("role");
        }
    }
}
