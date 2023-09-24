using ShippingStudio.Domain.Entities;
using ShippingStudio.Domain.Interfaces.Repository;
using ShippingStudio.Domain.Models.RequestModels;
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

        public List<Supplier?> GetAllSuppliers()
        {
            return supplierRepository.GetAll().ToList();
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

            if (String.IsNullOrEmpty(supplier.ContactPerson) || supplier.ContactPerson.Length < 3)
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
                DefaultCurrency = supplier.DefaultCurrency,
                Email = supplier.Email,
                ShippingPortId = supplier.ShippingPortId,
                TelephoneNumebr = supplier.TelephoneNumebr,
            };

            var result = supplierRepository.Add(supplierRecord);

            if (result != true || result is null)
            {
                response.Code = 10;
                response.Message = $"Supplier {supplier.Company} not been created, checked fields...";
                return response;
            }

            response.Code = 0;
            response.Message = $"Supplier {supplier.Company} has been created successfully...";
            return response;
        }

        private bool SupplierExists(string Suppliername)
        {
            var existing = supplierRepository.GetAll().Where(x => x.Company == Suppliername).FirstOrDefault();

            if (existing != null) { return true; }

            return false;
        }
    }
}
