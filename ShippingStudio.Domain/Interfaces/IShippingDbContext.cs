using Microsoft.EntityFrameworkCore;
using ShippingStudio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingStudio.Domain.Interfaces
{
    public interface IShippingDbContext
    {
        DbSet<Currency> Currency { get; set; }
        DbSet<Supplier> Suppliers { get; set; }
        DbSet<ShippingPort> ShippingPorts { get; set; }
        DbSet<Filing> Filing { get; set; }
        DbSet<FileStatuses> FileStatuses { get; set; }  
        DbSet<Order> Orders { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<PackingList> PackingList { get; set; }   
        DbSet<OrderStatus> OrderStatuses { get; set; }
        DbSet<OrderLines> OrderLines { get; set; }  
        DbSet<LineStatus> LineStatuses { get; set; }
        DbSet<Incoterm> Incoterms { get; set; }
        


    }
}
