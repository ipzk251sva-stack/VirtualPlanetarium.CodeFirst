using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualPlanetarium.CodeFirst.Models;

namespace VirtualPlanetarium.CodeFirst.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Reviews");
            builder.HasKey(r => r.Id);
            
            builder.Property(r => r.Comment).HasMaxLength(500);
            builder.Property(r => r.CreatedAt).HasDefaultValueSql("GETDATE()");

            // Constraint на рейтинг
            builder.ToTable(t => t.HasCheckConstraint("CK_Reviews_Rating", "[Rating] >= 1 AND [Rating] <= 5"));

            // Зв'язки
            builder.HasOne(r => r.User)
                .WithMany() // Можна додати колекцію Reviews в User, але не обов'язково
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.CelestialObject)
                .WithMany() // Можна додати колекцію Reviews в CelestialObject
                .HasForeignKey(r => r.CelestialObjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}