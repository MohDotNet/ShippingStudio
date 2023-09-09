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

    }
}
