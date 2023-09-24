using ShippingStudio.Domain.Entities;

namespace ShippingStudio.Domain.Models.ResponseModels
{
    public class DbSupplierResponseModel : BaseResponseModel
    {
        public DbSupplierResponseModel()
        {
            Code = 0;
            Suppliers = new List<Supplier>();   
        }

        public Supplier? Supplier { get; set; }

        public List<Supplier> Suppliers { get; set; }
    }
}
