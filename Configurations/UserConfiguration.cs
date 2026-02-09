using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualPlanetarium.CodeFirst.Models;

namespace VirtualPlanetarium.CodeFirst.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Email)
                .HasMaxLength(100);

            builder.Property(u => u.ObsCount)
                .HasDefaultValue(0);

            builder.HasIndex(u => u.UserName)
                .IsUnique();

            builder.HasIndex(u => u.Email)
                .IsUnique()
                .HasFilter("[Email] IS NOT NULL");

            // === ЗАВДАННЯ 6: Owned Entity ===
            builder.OwnsOne(u => u.Address, a =>
            {
                a.Property(p => p.City).HasMaxLength(50).HasColumnName("City");
                a.Property(p => p.Country).HasMaxLength(50).HasColumnName("Country");
                a.Property(p => p.ZipCode).HasMaxLength(10).HasColumnName("ZipCode");
            });

            // === SEED DATA ===
            builder.HasData(
                new User { Id = 1, UserName = "admin", Email = "admin@planetarium.com", ObsCount = 0 }
            );
        }
    }
}