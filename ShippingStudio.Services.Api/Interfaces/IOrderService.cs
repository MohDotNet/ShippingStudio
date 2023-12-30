using ShippingStudio.Domain.Models.RequestModels.Order;
using ShippingStudio.Domain.Models.ResponseModels;
using ShippingStudio.Domain.Models.ResponseModels.Order;

namespace ShippingStudio.Services.Api.Interfaces
{

    /// <summary>
    /// Responsible for order creation and management.  Core functionality.
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Create a new order.  This will create the order header and order lines.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        OrderResponseModel CreateOrder(CreateOrderRequestModel request);


        /// <summary>
        /// The Supplier will confirm a purhcase order, generally by sending an Indent Document.
        /// Call this method to update the Order with the Indent Number.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        BaseResponseModel ConfirmPurchaseOrder(ConfirmPurchaseOrderModel request);

    }
}
