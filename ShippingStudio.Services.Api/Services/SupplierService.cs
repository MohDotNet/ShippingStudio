using ShippingStudio.Domain.Entities;
using ShippingStudio.Domain.Interfaces.Repository;
using ShippingStudio.Domain.Models.RequestModels;
using ShippingStudio.Domain.Models.RequestModels.Supplier;
using ShippingStudio.Domain.Models.ResponseModels;

namespace ShippingStudio.Services.Api.Services
{
    public class SupplierService
    {
        private readonly ISupplierRepository supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }

        public DbSupplierResponseModel GetSupplier(int id)
        {
            DbSupplierResponseModel response = new DbSupplierResponseModel();

            response.Supplier = supplierRepository.Get(id).Supplier;

            return response;
        }

        public DbSupplierResponseModel GetAllSuppliers()
        {
            return supplierRepository.GetAll();
        }

        public BaseResponseModel AddNewSupplier(AddNewSupplierRequestModel supplier)
        {
            var response = new BaseResponseModel();

            // validation

            #region Validation
            if (supplier == null)
            {
                response.Code = 1;
                response.Message = "Supplier object cannot be null when attempting to add a new supplier";
            }

            if (String.IsNullOrEmpty(supplier.Company) || supplier.Company.Length < 3)
            {
                response.Code = 2;
                response.Message = "Comopany name is invalid, null or empty";
            }

            if (string.IsNullOrEmpty(supplier.ContactPerson) || supplier.ContactPerson.Length < 3)
            {
                response.Code = 3;
                response.Message = "Supplier contact person name is invalid";
            }

            if (supplier.TelephoneNumebr.Length < 7 || String.IsNullOrEmpty(supplier.TelephoneNumebr))
            {
                response.Code = 4;
                response.Message = "Supplier telephone number is not valid";
            }

            if (SupplierExists(supplier.Company))
            {
                response.Code = 5;
                response.Message = "This supplier already exists";
            }

            if (response.Code != 0)
            {
                return response;
            }

            #endregion

            Supplier supplierRecord = new Supplier
            {
                Company = supplier.Company,
                ContactPerson = supplier.ContactPerson,
                CurrencyId = supplier.DefaultCurrency,
                Email = supplier.Email,
                ShippingPortId = supplier.ShippingPortId,
                TelephoneNumebr = supplier.TelephoneNumebr,
            };

            var result = supplierRepository.Add(supplierRecord);

            response.Code = 0;
            response.Message = $"Supplier {supplier.Company} has been created successfully...";

            if (result.Code != 0)
            {
                response.Code = 10;
                response.Message = $"Supplier {supplier.Company} not been created, checked fields...";
            }

            return response;
        }

        public BaseResponseModel UpdateSupplier(SupplierUpdateRequestModel supplier)
        {
            BaseResponseModel response = new BaseResponseModel();

            try
            {
                Supplier supplierRecord = new Supplier
                {
                    Id = supplier.Id,
                    Company = supplier.Company,
                    ContactPerson = supplier.ContactPerson,
                    CurrencyId = supplier.DefaultCurrency,
                    Email = supplier.Email,
                    ShippingPortId = supplier.ShippingPortId,
                    TelephoneNumebr = supplier.TelephoneNumebr
                };

                response = supplierRepository.Save(supplierRecord);

                if (response.Code != 0 || response == null)
                {
                    response.Message = $"Record not updated : {response.Message}";
                }

                return response;
            }
            catch (Exception ex)
            {
                response.Code = 500;
                response.Message = ex.Message;  
                return response;
                
            }
        } 

        private bool SupplierExists(string Suppliername)
        {
            var existing = supplierRepository.GetAll();

            var IsExisting = existing.Suppliers.Where(x => x.Company == Suppliername).FirstOrDefault();

            if (IsExisting != null) { return true; }

            return false;
        }
    }
}
