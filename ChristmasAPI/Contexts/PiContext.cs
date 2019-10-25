using ChristmasAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ChristmasAPI.Contexts {
    public class PiContext : DbContext {
        public PiContext(DbContextOptions<PiContext> options) : base(options)
        {
            //ensures that the database is created when entity framework runs updates
            Database.EnsureCreated();
        }

        public DbSet<Family> Families { get; set; }
        public DbSet<User> Users { get; set; }

        //creates singular table names but allows for pluralized model names
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.Relational().TableName = entityType.Name;
            }
        }
    }
}
