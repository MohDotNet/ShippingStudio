using Microsoft.AspNetCore.Mvc;
using ShippingStudio.Domain.Models.RequestModels.Shipping;
using ShippingStudio.Domain.Models.ResponseModels;
using ShippingStudio.Services.Api.Interfaces;

namespace ShippingStudio.Services.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController : ControllerBase
    {
        private readonly IShippingService _shippingService;

        public ShippingController(IShippingService shippingService)
        {
            _shippingService = shippingService;
        }

        [HttpPost("CapturePackingSlip")]
        public BaseResponseModel CapturePackingList(CapturePackingListRequest request)
        {
            return _shippingService.CapturePackingList(request);
        }

    }
}
