using ShippingStudio.Domain.Models.RequestModels.Order;
using ShippingStudio.Domain.Models.ResponseModels.Order;

namespace ShippingStudio.Services.Api.Interfaces
{
    public interface IOrderService
    {
        /// <summary>
        /// Create a new order.  This will create the order header and order lines.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        OrderResponseModel CreateOrder(CreateOrderRequestModel request);

    }
}
