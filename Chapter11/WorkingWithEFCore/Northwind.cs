using Microsoft.EntityFrameworkCore;

namespace Packt.Shared
{
    // This manages the connection to the database
    public class Northwind : DbContext
    {
        // These properties map the tables in the database
        public DbSet<Category> Categories {get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBiulder)
        {
            string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Northwind.db");

            optionsBiulder.UseSqlite($"Filename={path}");
        }

        // This method overrides holds top presidence and can be used to create all models and literally do everything if you want. 
        protected override void OnModelCreating( ModelBuilder modelBuilder)
        {
            // example of using Fluent API instead of attributes
            // to limit the length of a category name to 15
            modelBuilder.Entity<Category>()
            .Property(category => category.CategoryName)
            .IsRequired() // NOT NULL
            .HasMaxLength(15);

            // added to "fix" the lack of decimal support in SQLite
            modelBuilder.Entity<Product>()
            .Property(product => product.Cost)
            .HasConversion<double>();
        }
    }
}