using SmallBussinessMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallBussinessMS.DatabaseContext
{
    public class SBMSDbContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

    }
}
