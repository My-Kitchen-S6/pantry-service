using Microsoft.EntityFrameworkCore;
using pantry_service.Models;

namespace pantry_service.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<NutritionalValue> NutritionalValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasMany(p => p.Pantry)
                .WithOne(p => p.User!)
                .HasForeignKey(p => p.Id);

            modelBuilder
                .Entity<Ingredient>()
                .HasOne(p => p.User)
                .WithMany(p => p.Pantry)
                .HasForeignKey(p => p.UserId);
        }
    }
}