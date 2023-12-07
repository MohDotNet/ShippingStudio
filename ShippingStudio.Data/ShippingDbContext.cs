using Microsoft.EntityFrameworkCore;
using ShippingStudio.Domain.Entities;
using ShippingStudio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShippingStudio.Data
{
    public class ShippingDbContext : DbContext, IShippingDbContext
    {

        public ShippingDbContext(DbContextOptions options) :
            base(options)
        {

        }
        public DbSet<Currency> Currency { get; set ; }
        public DbSet<Supplier> Suppliers { get; set ; }
        public DbSet<ShippingPort> ShippingPorts { get; set ; }
        public DbSet<Filing> Filing { get; set; }
        public DbSet<FileStatuses> FileStatuses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PackingList> Packings { get; set; }


        protected override void Seed(ShippingDbContext context)
        {
            
        }


        
    }
}
