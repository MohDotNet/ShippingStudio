﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShippingStudio.Data;

#nullable disable

namespace ShippingStudio.Data.Migrations
{
    [DbContext(typeof(ShippingDbContext))]
    partial class ShippingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShippingStudio.Domain.Entities.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CurrencyCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("CurrencyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Currency");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CurrencyCode = "ZAR",
                            CurrencyName = "South African Rand",
                            IsDisabled = false
                        },
                        new
                        {
                            Id = 2,
                            CurrencyCode = "USD",
                            CurrencyName = "United States Dollar",
                            IsDisabled = false
                        });
                });

            modelBuilder.Entity("ShippingStudio.Domain.Entities.FileStatuses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("FileStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "New"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Open"
                        },
                        new
                        {
                            Id = 3,
                            Description = "OnHold"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Closed"
                        });
                });

            modelBuilder.Entity("ShippingStudio.Domain.Entities.Filing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FileCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("FileStatus")
                        .HasColumnType("int");

                    b.Property<int>("FileStatusesId")
                        .HasColumnType("int");

                    b.Property<string>("Filename")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FileStatusesId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Filing");
                });

            modelBuilder.Entity("ShippingStudio.Domain.Entities.Incoterm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("IncotermSymbol")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("InctermName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Incoterms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IncotermSymbol = "CIF",
                            InctermName = "Cost Insurance Freight"
                        },
                        new
                        {
                            Id = 2,
                            IncotermSymbol = "CFR",
                            InctermName = "Carriage Frieght"
                        },
                        new
                        {
                            Id = 3,
                            IncotermSymbol = "FOB",
                            InctermName = "Free On Board"
                        },
                        new
                        {
                            Id = 4,
                            IncotermSymbol = "FAS",
                            InctermName = "Free Alongside Ship"
                        },
                        new
                        {
                            Id = 5,
                            IncotermSymbol = "DDP",
                            InctermName = "Delviered Duty Paid"
                        },
                        new
                        {
                            Id = 6,
                            IncotermSymbol = "CIP",
                            InctermName = "Carriage Insurance Paid To"
                        });
                });

            modelBuilder.Entity("ShippingStudio.Domain.Entities.LineStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("LineStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "New"
                        },
                        new
                        {
                            Id = 2,
                            Description = "InProgress"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Complete"
                        },
                        new
                        {
                            Id = 4,
                            Description = "OnHold"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Cancelled"
                        });
                });

            modelBuilder.Entity("ShippingStudio.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<int>("IncotermId")
                        .HasColumnType("int");

                    b.Property<string>("IndentNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("InternalOrderReference")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("int");

                    b.Property<string>("PortDestination")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PortOfOrigin")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<string>("SupplierOrderReference")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("IncotermId");

                    b.HasIndex("OrderStatusId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ShippingStudio.Domain.Entities.OrderLines", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LineStatusId")
                        .HasColumnType("int");

                    b.Property<double>("LineTotal")
                        .HasColumnType("float");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TotalShipped")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LineStatusId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderLines");
                });

            modelBuilder.Entity("ShippingStudio.Domain.Entities.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("OrderStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "New"
                        },
                        new
                        {
                            Id = 2,
                            Description = "In Progress"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Complete"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Onhold"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Cancelled"
                        });
                });

            modelBuilder.Entity("ShippingStudio.Domain.Entities.PackingList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ArrivedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ContainerNumber")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("ContainerType")
                        .HasColumnType("int");

                    b.Property<DateTime>("CostingDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("CostingDone")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DeliveredDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("HasArrived")
                        .HasColumnType("bit");

                    b.Property<bool>("HasDelivered")
                        .HasColumnType("bit");

                    b.Property<bool>("HasDeparted")
                        .HasColumnType("bit");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PackedDated")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("QuantityCheckedIn")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ShipQuantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ShippedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<string>("WaybillNumber")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SupplierId");

                    b.ToTable("PackingList");
                });

            modelBuilder.Entity("ShippingStudio.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ShippingStudio.Domain.Entities.ShippingPort", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("bit");

                    b.Property<string>("Port")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("ShippingPorts");
                });

            modelBuilder.Entity("ShippingStudio.Domain.Entities.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ContactPerson")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<int>("DefaultCurrency")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("ShippingPortId")
                        .HasColumnType("int");

                    b.Property<string>("TelephoneNumebr")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("ShippingPortId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("ShippingStudio.Domain.Entities.Filing", b =>
                {
                    b.HasOne("ShippingStudio.Domain.Entities.FileStatuses", "FileStatuses")
                        .WithMany()
                        .HasForeignKey("FileStatusesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShippingStudio.Domain.Entities.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FileStatuses");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("ShippingStudio.Domain.Entities.Order", b =>
                {
                    b.HasOne("ShippingStudio.Domain.Entities.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShippingStudio.Domain.Entities.Incoterm", "Incoterm")
                        .WithMany()
                        .HasForeignKey("IncotermId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShippingStudio.Domain.Entities.OrderStatus", "OrderStatus")
                        .WithMany()
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShippingStudio.Domain.Entities.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("Incoterm");

                    b.Navigation("OrderStatus");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("ShippingStudio.Domain.Entities.OrderLines", b =>
                {
                    b.HasOne("ShippingStudio.Domain.Entities.LineStatus", "LineStatus")
                        .WithMany()
                        .HasForeignKey("LineStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShippingStudio.Domain.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShippingStudio.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LineStatus");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ShippingStudio.Domain.Entities.PackingList", b =>
                {
                    b.HasOne("ShippingStudio.Domain.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShippingStudio.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShippingStudio.Domain.Entities.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("ShippingStudio.Domain.Entities.Supplier", b =>
                {
                    b.HasOne("ShippingStudio.Domain.Entities.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShippingStudio.Domain.Entities.ShippingPort", "ShippingPort")
                        .WithMany()
                        .HasForeignKey("ShippingPortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("ShippingPort");
                });
#pragma warning restore 612, 618
        }
    }
}
