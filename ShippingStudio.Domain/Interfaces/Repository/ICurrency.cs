using ShippingStudio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingStudio.Domain.Interfaces.Repository
{
    public interface ICurrency
    {
        List<Currency> GetAll();
        Currency? Get(int id);   
        bool Add(Currency currency);
        Currency? Save(Currency currency);   

    }
}
