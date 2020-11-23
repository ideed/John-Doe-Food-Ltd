using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace John_Doe_Food_Ltd.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("LibraryContext")
        {

        }
       
        public DbSet<Catalouge> Catalouges { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasMany(o => o.Orders).WithRequired().HasForeignKey(h => h.CusId);
            modelBuilder.Entity<Catalouge>().HasMany(o => o.Orders).WithRequired().HasForeignKey(h => h.CatId);
        }
    }
}