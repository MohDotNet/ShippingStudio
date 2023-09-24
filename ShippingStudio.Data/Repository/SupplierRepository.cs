using ShippingStudio.Domain.Entities;
using ShippingStudio.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ShippingStudio.Data.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ShippingDbContext context;

        public SupplierRepository(ShippingDbContext context)
        {
            this.context = context;
        }

        public bool? Add(Supplier supplier)
        {
            if (supplier == null) return false;

            using (context)
            {

                Currency? currency = context.Currency.FirstOrDefault(x => x.Id == supplier.DefaultCurrency);
                ShippingPort? shippingPort = context.ShippingPorts.FirstOrDefault(x => x.Id == supplier.ShippingPortId);

                if (currency == null || shippingPort == null)
                {
                    return false;
                }

                supplier.ShippingPort = shippingPort;
                supplier.Currency = currency;

                context.Suppliers.Add(supplier);    
                context.SaveChanges();
                return true;
            }
        }

        public Supplier? Get(int id)
        {
            if (id <= 0) return null;   
            using (context)
            {
                return context.Suppliers.Where(x=> x.Id == id).FirstOrDefault();   
            }
        }

        public List<Supplier> GetAll()
        {
            return context.Suppliers.ToList();
        }

        public bool? Save(Supplier supplier)
        {
            Supplier? _original = context.Suppliers.Where(x=> x.Id == supplier.Id).FirstOrDefault();

            if (_original != null)
            {
                _original = supplier;
                context.SaveChanges();
            }
            return true;
        }
    }
}
