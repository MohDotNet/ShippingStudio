using ShippingStudio.Domain.Entities;
using ShippingStudio.Domain.Interfaces.Repository;

namespace ShippingStudio.Data.Repository
{
    public class ShippingPortRepository : IShippingPortRepository
    {
        private readonly ShippingDbContext context;

        public ShippingPortRepository(ShippingDbContext context)
        {
            this.context = context;
        }

        public bool? Add(ShippingPort shippingPort)
        {
            if (shippingPort == null) { return  false; }

            using (context)
            {
                context.ShippingPorts.Add(shippingPort);
                context.SaveChanges();
                return true;
            }
        }

        public ShippingPort? Get(int id)
        {
            return context.ShippingPorts.Where(x=> x.Id == id).FirstOrDefault();
        }

        public List<ShippingPort> GetAll()
        {
            return context.ShippingPorts.ToList();
        }

        public bool? Save(ShippingPort shippingPort)
        {
            if (shippingPort == null) return false;

            using (context)
            {
                ShippingPort? original = context.ShippingPorts.Where(x => x.Id == shippingPort.Id).FirstOrDefault();
                if (original is null) return false;

                original = shippingPort;
                context.SaveChanges();

                return true;
            }
            }
        }
}