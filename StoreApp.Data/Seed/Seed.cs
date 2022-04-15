using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Context;
using StoreApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Data.Seed
{
    public static class Seed
    {

        public static void SeedProducts(this ModelBuilder builder)
        {
            builder.Entity<Product>().HasData(new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Title = "Acer Laptop 755",
                    Description ="Laptop Acer 15.6, 256Gb, 8Gb ",
                    Price=900,
                    CatalogId=1,
                    SupplierId=3,
                    Stock=5
                    
                },
                new Product()
                {
                    Id = 2,
                    Title = "Apple Laptop MacbookPro",
                    Description ="Laptop Acer 13, 256Gb, 8Gb ",
                    Price=1200,
                    CatalogId=1,
                    SupplierId=2,
                    Stock=2

                }
            }); ;
        }
        public static void SeedCatalog(this ModelBuilder builder)
        {
            builder.Entity<Catalog>().HasData(new Catalog
            {
                Id=1,
                Name="Laptop",
                Avatar="laptop.jpg"
            });
        }

        public static void SeedSupplier(this ModelBuilder builder)
        {
            builder.Entity<Supplier>().HasData(new Supplier
            {
                Id=1,
                Name="Dell",
                Email="test@test.com",
                HomePage="www.domain.com",
                Phone="+20952553434"
            });

            builder.Entity<Supplier>().HasData(new Supplier
            {
                Id=2,
                Name="Apple",
                Email="office@apple.com",
                HomePage="www.apple.com",
                Phone="+145423434543"
            });

            builder.Entity<Supplier>().HasData(new Supplier
            {
                Id=3,
                Name="Acer",
                Email="office@acer.com",
                HomePage="www.acer.com",
                Phone="+34354655654"
            });
        }
     
    }
}
