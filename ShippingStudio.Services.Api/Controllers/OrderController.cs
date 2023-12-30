using Microsoft.AspNetCore.Mvc;
using ShippingStudio.Domain.Models.RequestModels.Order;
using ShippingStudio.Domain.Models.ResponseModels;
using ShippingStudio.Domain.Models.ResponseModels.Order;
using ShippingStudio.Services.Api.Interfaces;

namespace ShippingStudio.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("Create")]
        public OrderResponseModel CreateOrder(CreateOrderRequestModel request)
        {
            return _orderService.CreateOrder(request);
        }

        [HttpPost("ConfirmPurchaseOrder")]
        public BaseResponseModel ConfirmPurchaseOrder(ConfirmPurchaseOrderModel request)
        {
            return _orderService.ConfirmPurchaseOrder(request);
        }
    }
}
