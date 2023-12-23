using ShippingStudio.Domain.Entities;
using ShippingStudio.Domain.Interfaces.Repository;
using ShippingStudio.Domain.Models.ResponseModels;

namespace ShippingStudio.Data.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ShippingDbContext context;

        public SupplierRepository(ShippingDbContext context)
        {
            this.context = context;
        }

        public BaseResponseModel? Add(Supplier supplier)
        {
            BaseResponseModel response = new BaseResponseModel();

            if (supplier == null)
            {
                response.Code = 1;
                response.Message = "Supplier object cannot be null.";
                return response;
            }

            using (context)
            {

                Currency? currency = context.Currency.FirstOrDefault(x => x.Id == supplier.CurrencyId);
                ShippingPort? shippingPort = context.ShippingPorts.FirstOrDefault(x => x.Id == supplier.ShippingPortId);

                if (currency == null || shippingPort == null)
                {
                    response.Code = 1;
                    response.Message = "Currency and or shipping port cannot be null";
                    return response;
                }

                supplier.ShippingPort = shippingPort;
                supplier.CurrencyId = currency.Id;
                

                context.Suppliers.Add(supplier);    
                context.SaveChanges();
                response.Code = 0;
                response.Message = "Supplier has beeen successfully written to the database.";

                return response;
            }
        }

        public DbSupplierResponseModel Get(int id)
        {
            DbSupplierResponseModel response = new DbSupplierResponseModel();

            if (id <= 0)
            {
                response.Code = 1;
                response.Message = "Invalid Id specified to do a lookup.";
            }

            response.Supplier = context.Suppliers.Where(x=> x.Id == id).FirstOrDefault();   

            if (response.Supplier == null) 
            { 
                response.Code = 1;
                response.Message = "Cannot find supplier";
            }
            return response;
        }

        public DbSupplierResponseModel GetAll()
        {
            var response = new DbSupplierResponseModel();
            try
            {
                response.Suppliers = context.Suppliers.ToList();

                response.Code = 0;
                response.Message = "List of suppliers retrieved...";
                return response;
            }
            catch (Exception ex)
            {
                response.Code = 1;
                response.Message = "The following error has occurred : DB Error - Should this error persist, check logs.";
                return response;
            }
        }

        public BaseResponseModel Save(Supplier supplier)
        {
            BaseResponseModel response = new BaseResponseModel();

            try
            {
                Supplier? _original = context.Suppliers.Where(x => x.Id == supplier.Id).FirstOrDefault();

                if (_original != null)
                {
                    _original = supplier;
                    context.SaveChanges();

                    response.Code = 0;
                    response.Message = "SAVE SUPPLIER | Successfully written data";
                }

                return response;
            }
            catch (Exception)
            {
                response.Code = 1;
                response.Message = "The following error has occurred : DB Error - Should this error persist, check logs.";
                return response;
            }
        }
    }
}
