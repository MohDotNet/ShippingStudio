using ShippingStudio.Domain.Entities;
using ShippingStudio.Domain.Interfaces.Repository;

namespace ShippingStudio.Data.Repository
{
    public class CurrencyRepository : ICurrency
    {
        private readonly ShippingDbContext context;

        public CurrencyRepository(ShippingDbContext context)
        {
            this.context = context;
        }

        public bool Add(Currency currency)
        {
            if(currency == null) return false;  

            using (context)
            {
                context.Currency.Add(currency);
                context.SaveChanges();
                return true;
            }
        }

        public Currency? Get(int id)
        {
            if (id <= 0) return new Currency();
            
            return context.Currency.Where(x => x.Id == id)
                    .FirstOrDefault();
            
        }

        public List<Currency> GetAll()
        {
            using (context)
            {
                return context.Currency.ToList();
            }
        }

        public Currency? Save(Currency currency)
        {
            Currency? _original = context.Currency.Where(x=> x.Id == currency.Id).FirstOrDefault();    

            if (_original == null) 
            { 
                return _original;
            }

            currency.Id = _original.Id;
            _original = currency;


            using (context)
            {
                context.SaveChanges(true);
            }

            return _original;

        }
    }
}
