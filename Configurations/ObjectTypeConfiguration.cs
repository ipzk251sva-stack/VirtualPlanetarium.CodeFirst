using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualPlanetarium.CodeFirst.Models;

namespace VirtualPlanetarium.CodeFirst.Configurations
{
    public class ObjectTypeConfiguration : IEntityTypeConfiguration<ObjectType>
    {
        public void Configure(EntityTypeBuilder<ObjectType> builder)
        {
            builder.ToTable("ObjectTypes");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name).IsRequired().HasMaxLength(50);
            builder.HasIndex(t => t.Name).IsUnique();

            // === SEED DATA (Завдання 4) ===
            builder.HasData(
                new ObjectType { Id = 1, Name = "Star" },
                new ObjectType { Id = 2, Name = "Planet" },
                new ObjectType { Id = 3, Name = "Galaxy" },
                new ObjectType { Id = 4, Name = "Nebula" }
            );
        }
    }
}