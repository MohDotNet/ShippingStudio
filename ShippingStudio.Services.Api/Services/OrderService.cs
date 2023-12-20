using ShippingStudio.Domain.Interfaces.Repository;
using ShippingStudio.Domain.Models.RequestModels.Order;
using ShippingStudio.Domain.Models.ResponseModels.Order;
using ShippingStudio.Services.Api.Interfaces;

namespace ShippingStudio.Services.Api.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IOrderLinesRepository orderLinesRepository;

        public OrderService(IOrderRepository orderRepository, IOrderLinesRepository orderLinesRepository)
        {
            this.orderRepository = orderRepository;
            this.orderLinesRepository = orderLinesRepository;
        }

        public OrderResponseModel CreateOrder(CreateOrderRequestModel request)
        {
            throw new NotImplementedException();
        }
    }
}
