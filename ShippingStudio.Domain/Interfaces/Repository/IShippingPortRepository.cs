using ShippingStudio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingStudio.Domain.Interfaces.Repository
{
    public interface IShippingPortRepository
    {
        List<ShippingPort> GetAll();
        ShippingPort? Get(int id);
        bool? Add(ShippingPort shippingPort);
        bool? Save(ShippingPort shippingPort);

    }
}
