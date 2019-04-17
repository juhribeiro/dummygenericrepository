using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Teste.Data;

namespace Teste.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Data.CategoryEntity> Categories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Data.CategoryEntity>().ToTable("Categories");
            builder.Entity<Data.CategoryEntity>().HasKey(p => p.Id);
            builder.Entity<Data.CategoryEntity>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Data.CategoryEntity>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Data.CategoryEntity>().HasMany(p => p.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);


            var blz = new List<ProductEntity>(){
            new ProductEntity
               {
                   Id = 100,
                   Name = "Fruits and Vegetables",
                   CategoryId = 100
               }, // Id set manually due to in-memory provider
               new ProductEntity
               {
                   Id = 101,
                   Name = "Dairy",
                   CategoryId = 100
               }};

            builder.Entity<Data.CategoryEntity>().HasData
            (
                new Data.CategoryEntity
                {
                    Id = 100,
                    Name = "Fruits and Vegetables"

                }, // Id set manually due to in-memory provider
                new Data.CategoryEntity
                {
                    Id = 101,
                    Name = "Dairy"
                }
            );

            builder.Entity<ProductEntity>().ToTable("Products");
            builder.Entity<ProductEntity>().HasKey(p => p.Id);
            builder.Entity<ProductEntity>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<ProductEntity>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<ProductEntity>().Property(p => p.QuantityInPackage).IsRequired();

        }
    }
}