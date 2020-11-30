using DataLayerEF.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerEF
{
    public class AppEFContext: DbContext
    {
        public DbSet<Agency> Agencies;
        public DbSet<Agent> Agents;
        public DbSet<Contact> Contacts;

        public AppEFContext(DbContextOptions<AppEFContext> options):base(options)
        {
            //Database.EnsureCreated();
            //Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agency>()
                .HasMany<Agent>(ac => ac.Agents)
                .WithMany(at => at.Agencies);


            modelBuilder.Entity<Agent>()
                .HasMany<Agency>(at => at.Agencies)
                .WithMany(ac => ac.Agents);
        }
    }
}
