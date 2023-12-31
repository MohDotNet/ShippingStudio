﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ShippingStudio.Domain.Entities;
using ShippingStudio.Domain.Interfaces;
using ShippingStudio.Domain.Models.ResponseModels;

namespace ShippingStudio.Data
{
    public class ShippingDbContext : DbContext, IShippingDbContext
    {

        public ShippingDbContext(DbContextOptions options) :
            base(options)
        {

        }

        #region Database Tables
        public DbSet<Currency> Currency { get; set; }
        public DbSet<CheckList> CheckList { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ShippingPort> ShippingPorts { get; set; }
        public DbSet<Filing> Filing { get; set; }
        public DbSet<FileStatuses> FileStatuses { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<LineStatus> LineStatuses { get; set; }
        public DbSet<Incoterm> Incoterms { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLines> OrderLines { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PackingList> PackingList { get; set; }
        #endregion

        #region Stored Procedures
        public BaseResponseModel ConfirmOrder(string IndentNumber, int OrderId)
        {
            SqlParameter orderId = new SqlParameter("orderId", OrderId);
            SqlParameter indentNumber = new SqlParameter("indentNumber", IndentNumber);


            BaseResponseModel? result = Set<BaseResponseModel>().FromSqlRaw("EXEC SupplierConfirmOrder @orderId, @indentNumber", orderId, indentNumber)
                .AsEnumerable()
                .SingleOrDefault();

            return result;
        }


        #endregion

        // Seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<BaseResponseModel>().HasNoKey();

            modelBuilder.Entity<Currency>()
                .HasData(
                    new Currency { Id = 1, CurrencyName = "South African Rand", CurrencyCode = "ZAR", IsDisabled = false },
                    new Currency { Id = 2, CurrencyName = "United States Dollar", CurrencyCode = "USD", IsDisabled = false }
                 );

            modelBuilder.Entity<FileStatuses>()
                .HasData(
                    new FileStatuses { Id = 1, Description = "New" },
                    new FileStatuses { Id = 2, Description = "Open" },
                    new FileStatuses { Id = 3, Description = "OnHold" },
                    new FileStatuses { Id = 4, Description = "Closed" }
                );

            modelBuilder.Entity<OrderStatus>()
                .HasData(
                new OrderStatus { Id = 1, Description = "New" },
                new OrderStatus { Id = 2, Description = "In Progress" },
                new OrderStatus { Id = 3, Description = "Complete" },
                new OrderStatus { Id = 4, Description = "Onhold" },
                new OrderStatus { Id = 5, Description = "Cancelled" }
                );

            modelBuilder.Entity<LineStatus>()
                .HasData(
                new LineStatus { Id = 1, Description = "New" },
                new LineStatus { Id = 2, Description = "InProgress" },
                new LineStatus { Id = 3, Description = "Complete" },
                new LineStatus { Id = 4, Description = "OnHold" },
                new LineStatus { Id = 5, Description = "Cancelled" });

            modelBuilder.Entity<Incoterm>()
                .HasData(
                new Incoterm { Id = 1, InctermName = "Cost Insurance Freight", IncotermSymbol = "CIF" },
                new Incoterm { Id = 2, InctermName = "Carriage Frieght", IncotermSymbol = "CFR" },
                new Incoterm { Id = 3, InctermName = "Free On Board", IncotermSymbol = "FOB" },
                new Incoterm { Id = 4, InctermName = "Free Alongside Ship", IncotermSymbol = "FAS" },
                new Incoterm { Id = 5, InctermName = "Delviered Duty Paid", IncotermSymbol = "DDP" },
                new Incoterm { Id = 6, InctermName = "Carriage Insurance Paid To", IncotermSymbol = "CIP" }

                );

            modelBuilder.Entity<Product>()
                .HasData(
                new Product { Id = 1, Description = "Admin Test Product", IsDisabled = false });


            modelBuilder.Entity<ShippingPort>()
                .HasData(new ShippingPort { Id = 1, Port = "Cape Town", Country = "South Africa", IsDisabled = false });

            modelBuilder.Entity<Supplier>()
                .HasData(new Supplier { Id = 1, Company = "Admin Company Ltd.", ContactPerson = "Mohamed", CurrencyId = 1, Email = "Ameerodien@outlook.com", ShippingPortId = 1, TelephoneNumebr = "0837985535" });



        }
    }
}
