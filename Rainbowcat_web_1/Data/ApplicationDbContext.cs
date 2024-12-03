using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rainbowcat_web_1.Models;
using System.Security.Cryptography.X509Certificates;

namespace Rainbowcat_web_1.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { 
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> OrdersItem { get; set; }
        public DbSet<Ingredient> Ingredients { get; set;}
        public DbSet<ProductIngredient> ProductIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ProductIngredient>()
                .HasOne(pi => new { pi.ProductId, pi.IngredientId });

            builder.Entity<ProductIngredient>()
                .HasOne(pi=>pi.Product)
                .WithMany(pi=>pi.ProductIngredients)
                .HasForeignKey(pi=>pi.ProductId);

            builder.Entity<ProductIngredient>()
                .HasOne(pi=>pi.Ingredient)
                .WithMany(i=>i.ProductIngredients)
                .HasForeignKey(pi=>pi.IngredientId);

            //seed Data
            builder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Appetizer" },
                new Category { CategoryId = 2, Name = "Entree" },
                new Category { CategoryId = 3, Name = "Side Dish" },
                new Category { CategoryId = 4, Name = "Dessert" },
                new Category { CategoryId = 5, Name = "Beverage" }
                );

            builder.Entity<Ingredient>().HasData(
                new Ingredient { IngredientId = 1, Name = "Beef" },
                new Ingredient { IngredientId = 2, Name = "Chicken" },
                new Ingredient { IngredientId = 3, Name = "Fish" },
                new Ingredient { IngredientId = 4, Name = "Torrilla" },
                new Ingredient { IngredientId = 5, Name = "Lettuce" },
                new Ingredient { IngredientId = 6, Name = "Tomato" }
                );
        }

    }
}