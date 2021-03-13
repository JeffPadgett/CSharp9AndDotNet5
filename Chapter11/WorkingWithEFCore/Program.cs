using System;
using Packt.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using static System.Console;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Storage;


namespace WorkingWithEFCore
{
    class Program
    {

        static void QueryingWithLike()
        {
            using (var db = new Northwind())
            {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());

                Write("Enter part of a product name: ");
                string input = ReadLine();

                IQueryable<Product> prods = db.Products
                .Where(p => EF.Functions.Like(p.ProductName, $"%{input}"));

                foreach (Product item in prods)
                {
                    WriteLine($"{item.ProductName} has {item.Stock} units in stock. Discontinued? {item.Discontinued}");
                }
            }
        }

        static void QueryingCategories()
        {
            using (var db = new Northwind())
            {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());
                WriteLine("Categories and how many products they have: ");

                // a query to get all categories and their related products
                IQueryable<Category> cats; //= db.Categories;//Include(c => c.Products); - This is eager loading if it is enabled
                db.ChangeTracker.LazyLoadingEnabled = false;

                Write("Enable eager loading? (Y/N): ");
                bool eagerloading = (ReadKey().Key == ConsoleKey.Y);
                bool explicitloading = false;
                WriteLine();

                if (eagerloading)
                {
                    cats = db.Categories.Include(c => c.Products);
                }
                else
                {
                    cats = db.Categories;

                    Write("Enable explicit loading? (Y/N): ");
                    explicitloading = (ReadKey().Key == ConsoleKey.Y);
                    WriteLine();
                }

                foreach (Category c in cats)
                {
                    if (explicitloading)
                    {
                        Write($"Explicitly load products for {c.CategoryName}? (Y/N)");
                        ConsoleKeyInfo key = ReadKey();
                        WriteLine();
                        if (key.Key == ConsoleKey.Y)
                        {
                            var products = db.Entry(c).Collection(c2 => c2.Products);
                            if (!products.IsLoaded) products.Load();
                        }
                    }
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

        //Inserting Entities
        static bool AddProduct(int categoryID, string productName, decimal? price)
        {
            using (var db = new Northwind())
            {
                var newProduct = new Product
                {
                    CategoryID = categoryID,
                    ProductName = productName,
                    Cost = price
                };

                // mark product as added in change tracking
                db.Products.Add(newProduct);

                // save tracked change to database
                int affected = db.SaveChanges();//the db saves changes, returns the number, it will always be 1, so then 1 is used as bool confirmation
                return (affected == 1);
            }
        }

        static void ListProducts()
        {
            using (var db = new Northwind())
            {
                WriteLine($"{"ID",-3} {"Product name":, -35} {"Cost",8}, {"Stock",5} {"Disk"} ");

                foreach (var item in db.Products.OrderByDescending(p => p.Cost))
                {   // -35 means left alignargument 1 with a 35 character wide column, and 5 means right -align argument
                    // number 3 with a 5 character-wide column
                    WriteLine($"{item.ProductID,000} {item.ProductName,-35} {item.Cost,8:$#,##0.00} {item.Stock,5} {item.Discontinued}");
                }
            }
        }
        // Updating/Modifying entities
        static bool IncreaseProductPrice(string name, decimal amount)
        {
            using (var db = new Northwind())
            {
                // get first product whos name starts with name
                Product updateProduct = db.Products.First(p => p.ProductName.StartsWith(name));

                updateProduct.Cost += amount;
                int affected = db.SaveChanges();
                return (affected == 1);
            }
        }

        // static int DeleteProducts(string name)
        // {
        //     using (var db = new Northwind())
        //     {
        //         IEnumerable<Product> products = db.Products.Where(p => p.ProductName.StartsWith(name));

        //         db.Products.RemoveRange(products);
        //         int affected = db.SaveChanges();
        //         return affected;
        //     }
        // }

        static int DeleteProducts(string name)
        {
            using (var db = new Northwind())
            {
                using (IDbContextTransaction t = db.Database.BeginTransaction())
                {
                    WriteLine($"Transaction isolation level: {t.GetDbTransaction().IsolationLevel}");

                    var products = db.Products.Where(p => p.ProductName.StartsWith(name));

                    db.Products.RemoveRange(products);

                    int affected = db.SaveChanges();
                    t.Commit();
                    return affected;
                }
            }
        }


        static void Main(string[] args)
        {
            //QueryingCategories();
            //FilteredIncludes();
            //QueryingProducts();
            //QueryingWithLike();

            // if (AddProduct(6, "Bob's burgers", 500M))
            // {
            //     WriteLine("Add product successful.");
            // }
            // if (IncreaseProductPrice("Bob", 20M))
            // {
            //     WriteLine("Update productd price successful.");
            // }
            // ListProducts();
            int deleted = DeleteProducts("Bob");
            WriteLine($"{deleted} product(s) were deleted.");
            ListProducts();
        }
    }
}
