using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using StoreApp.Data.Configuration;
using StoreApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using StoreApp.Data.Seed;

namespace StoreApp.Data.Context
{
    public class GlobalContext:DbContext
    {
        public GlobalContext()
        {

        }

        public GlobalContext(DbContextOptions<GlobalContext> options)
            : base(options)
        {

        }

        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ConversionRate> ConversionRates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CatalogConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
      

            modelBuilder.Entity<OrderDetail>()
                .HasOne(x => x.Order)
                .WithMany(x => x.OrderDetails).HasForeignKey(x => x.UserId);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(x => x.User)
                .WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderId);

            modelBuilder.Entity<OrderDetail>().ToTable("UserOrder");


            modelBuilder.SeedCatalog();
            modelBuilder.SeedSupplier();
            modelBuilder.SeedProducts();

           
        }
    }
}
