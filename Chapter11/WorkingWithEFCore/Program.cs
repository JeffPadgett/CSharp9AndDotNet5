using System;
using Packt.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using static System.Console;

namespace WorkingWithEFCore
{
    class Program
    {

        static void QueryingCategories()
        {
            using (var db = new Northwind())
            {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());
                WriteLine("Categories and how many products they have: ");

                // a query to get all categories and their related products
                IQueryable<Category> cats = db.Categories.Include(c => c.Products);

                foreach (Category c in cats)
                {
                    WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
                }
            }
        }

        static void FilteredIncludes()
        {
            using (var db = new Northwind())
            {
                Write($"Enter a minimum for units in stocks: ");
                string unitsInStock = ReadLine();
                int stock = int.Parse(unitsInStock);

                IQueryable<Category> categories = db.Categories.Include(c => c.Products.Where(p => p.Stock >= stock));

                WriteLine();
                WriteLine($"ToQueryString: {categories.ToQueryString()}");//You can write this pretty much anywhere to visually see the generated SQL.
                WriteLine();

                foreach (Category c in categories)
                {
                    WriteLine($"{c.CategoryName} has {c.Products.Count} products with a minimum of {stock} units in stock.");

                    foreach (Product p in c.Products)
                    {
                        WriteLine($" {p.ProductName} has {p.Stock} units in stock.");
                    }
                }
            }
        }

        static void QueryingProducts()
        {
            using (var db = new Northwind())
            {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());
                WriteLine("Products that cost more then a price, highest at top.");
                string input;
                decimal price;
                do
                {
                    Write("Enter a product price: ");
                    input = ReadLine();
                } while (!decimal.TryParse(input, out price));

                IQueryable<Product> prods = db.Products
                .Where(product => product.Cost > price)
                .OrderByDescending(product => product.Cost);

                foreach (Product item in prods)
                {
                    WriteLine($"{item.ProductID}: {item.ProductName} cost {item.Cost} and has {item.Stock} in stock.");
                }
            }
        }
        static void Main(string[] args)
        {
            QueryingCategories();
            //FilteredIncludes();
            //QueryingProducts();

        }
    }
}
