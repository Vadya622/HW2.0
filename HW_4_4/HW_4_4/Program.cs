using Microsoft.EntityFrameworkCore;

namespace YourNamespace
{
    public class PetContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("YourConnectionString");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Category).IsRequired();
                entity.Property(e => e.Breed).IsRequired();
                entity.Property(e => e.Age);
                entity.Property(e => e.Location).IsRequired();
                entity.Property(e => e.Image);
                entity.Property(e => e.Description);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CategoryName).IsRequired();
            });

            modelBuilder.Entity<Breed>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.BreedName).IsRequired();
                entity.HasOne(e => e.Category)
                      .WithMany()
                      .HasForeignKey(e => e.CategoryId);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.LocationName).IsRequired();
            });
        }
    }

    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public string Location { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }

    public class Breed
    {
        public int Id { get; set; }
        public string BreedName { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

    public class Location
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
    }
}
