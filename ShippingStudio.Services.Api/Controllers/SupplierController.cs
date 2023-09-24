using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShippingStudio.Domain.Entities;
using ShippingStudio.Domain.Models.RequestModels;
using ShippingStudio.Domain.Models.RequestModels.Supplier;
using ShippingStudio.Domain.Models.ResponseModels;
using ShippingStudio.Services.Api.Services;

namespace ShippingStudio.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly SupplierService supplierService;

        public SupplierController(SupplierService supplierService)
        {
            this.supplierService = supplierService;
        }

        [HttpGet("getall")]
        public DbSupplierResponseModel GetAll()
        {
            return supplierService.GetAllSuppliers();
        }

        [HttpPost("Create")]
        public BaseResponseModel Create(AddNewSupplierRequestModel supplier)
        {
            return supplierService.AddNewSupplier(supplier);
        }

        [HttpGet("GetById")]
        public DbSupplierResponseModel Get(int id)
        {
            return supplierService.GetSupplier(id);
        }

        [HttpPut("Update")]
        public BaseResponseModel Update(SupplierUpdateRequestModel supplier)
        {
            return supplierService.UpdateSupplier(supplier);
        }


    }
}
