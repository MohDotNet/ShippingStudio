using ShippingStudio.Domain.Entities;
using ShippingStudio.Domain.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingStudio.Domain.Interfaces.Repository
{
    public interface ISupplierRepository
    {
        DbSupplierResponseModel GetAll();
        DbSupplierResponseModel Get(int id);
        BaseResponseModel? Add(Supplier supplier);   
        BaseResponseModel? Save(Supplier supplier);
    }
}
