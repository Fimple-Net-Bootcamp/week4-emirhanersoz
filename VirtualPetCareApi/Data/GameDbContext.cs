using Microsoft.EntityFrameworkCore;
using VirtualPetCareApi.Models;

namespace VirtualPetCareApi.Database
{
    public class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<HealthStatus> HealthStatuses { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<SocialInteraction> SocialInteractions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivityPet>().HasKey(pt => new { pt.PetId, pt.ActivityId});
            modelBuilder.Entity<ActivityPet>().HasOne(pt => pt.Pet).WithMany(pt => pt.ActivityPets).HasForeignKey(pt => pt.PetId);
            modelBuilder.Entity<ActivityPet>().HasOne(pt => pt.Activity).WithMany(pt => pt.ActivityPets).HasForeignKey(pt => pt.ActivityId);

            modelBuilder.Entity<FoodPet>().HasKey(fp => new { fp.PetId, fp.FoodId });
            modelBuilder.Entity<FoodPet>().HasOne(fp => fp.Pet).WithMany(p => p.FoodPets).HasForeignKey(fp => fp.PetId);
            modelBuilder.Entity<FoodPet>().HasOne(fp => fp.Food).WithMany(f => f.FoodPets).HasForeignKey(fp => fp.FoodId);
        }
    }
}
