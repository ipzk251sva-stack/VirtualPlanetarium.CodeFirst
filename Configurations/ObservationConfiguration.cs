using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualPlanetarium.CodeFirst.Models;

namespace VirtualPlanetarium.CodeFirst.Configurations
{
    public class ObservationConfiguration : IEntityTypeConfiguration<Observation>
    {
        public void Configure(EntityTypeBuilder<Observation> builder)
        {
            builder.ToTable("Observations");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.ObservationDate)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(o => o.Notes)
                .HasMaxLength(1000);

            builder.HasOne(o => o.User)
                .WithMany(u => u.Observations)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.CelestialObject)
                .WithMany(c => c.Observations)
                .HasForeignKey(o => o.CelestialObjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}