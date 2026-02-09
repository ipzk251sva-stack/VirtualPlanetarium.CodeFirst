using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualPlanetarium.CodeFirst.Models;

namespace VirtualPlanetarium.CodeFirst.Configurations
{
    public class ObjectGroupConfiguration : IEntityTypeConfiguration<ObjectGroup>
    {
        public void Configure(EntityTypeBuilder<ObjectGroup> builder)
        {
            builder.ToTable("ObjectGroups");
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(g => g.GroupCode).HasMaxLength(10);

            builder.HasIndex(g => g.Name).IsUnique();

            // === SEED DATA ===
            builder.HasData(
                new ObjectGroup { Id = 1, Name = "Solar System" },
                new ObjectGroup { Id = 2, Name = "Local Group" },
                new ObjectGroup { Id = 3, Name = "Deep Space" }
            );
        }
    }
}