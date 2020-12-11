using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayerEF
{
    public class AppEFContext: DbContext
    {
        public DbContextOptions<AppEFContext> Options { get; }
        public DbSet<Agency> Agencies { get; set; } 
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public AppEFContext(DbContextOptions<AppEFContext> options):base(options)
        {
            Options = options;
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agency>()
                .ToTable("Agency")
                .HasMany<Agent>(ac => ac.Agents)
                .WithMany(at => at.Agencies);

            modelBuilder.Entity<Agent>()
                .ToTable("Agent")
                .HasMany<Agency>(at => at.Agencies)
                .WithMany(ac => ac.Agents);

            modelBuilder.Entity<Contact>()
                .ToTable("Contact");
        }
    }
}
