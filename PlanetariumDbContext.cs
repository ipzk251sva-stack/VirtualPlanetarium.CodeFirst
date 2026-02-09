using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; 
using VirtualPlanetarium.CodeFirst.Models;

namespace VirtualPlanetarium.CodeFirst
{
    public class PlanetariumDbContext : IdentityDbContext
    {
        public PlanetariumDbContext(DbContextOptions<PlanetariumDbContext> options)
            : base(options)
        {
        }
        public DbSet<CelestialObject> CelestialObjects => Set<CelestialObject>();
        public DbSet<ObjectGroup> ObjectGroups => Set<ObjectGroup>();
        public DbSet<ObjectType> ObjectTypes => Set<ObjectType>();
        public DbSet<Observation> Observations => Set<Observation>();
        public DbSet<Review> Reviews => Set<Review>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}