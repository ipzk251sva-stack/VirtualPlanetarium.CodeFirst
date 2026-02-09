using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualPlanetarium.CodeFirst.Models;

namespace VirtualPlanetarium.CodeFirst.Configurations
{
    public class CelestialObjectConfiguration : IEntityTypeConfiguration<CelestialObject>
    {
        public void Configure(EntityTypeBuilder<CelestialObject> builder)
        {
            builder.ToTable("CelestialObjects");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Description)
                .HasMaxLength(500);

            builder.Property(e => e.RightAscension)
                .HasColumnType("decimal(9,6)");

            builder.Property(e => e.Declination)
                .HasColumnType("decimal(9,6)");

            builder.Property(e => e.SpectralClass).HasMaxLength(20);

            builder.HasOne(d => d.Type)
                .WithMany(p => p.CelestialObjects)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Group)
                .WithMany(p => p.CelestialObjects)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.SetNull);

            // === SEED DATA ===
            builder.HasData(
                new CelestialObject 
                { 
                    Id = 1, 
                    Name = "Sun", 
                    Description = "The star at the center of the Solar System",
                    TypeId = 1, // Star
                    GroupId = 1 // Solar System
                },
                new CelestialObject 
                { 
                    Id = 2, 
                    Name = "Earth", 
                    Description = "Our home planet",
                    TypeId = 2, // Planet
                    GroupId = 1 // Solar System
                },
                new CelestialObject 
                { 
                    Id = 3, 
                    Name = "Andromeda", 
                    Description = "Nearest major galaxy",
                    TypeId = 3, // Galaxy
                    GroupId = 2 // Local Group
                }
            );
        }
    }
}