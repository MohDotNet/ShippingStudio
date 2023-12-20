using ShippingStudio.Domain.DTO;
using ShippingStudio.Domain.Enums;

namespace ShippingStudio.Domain.Models.RequestModels.Order
{
    public class CreateOrderRequestModel 
    {
        public CreateOrderRequestModel()
        {
            OrderDate = DateTime.Now;
            OrderStatusId = (int)OrderStatus.New;
        }

        public int SupplierId { get; set; }
        public DateTime OrderDate { get; set; }
        public string InternalOrderReference { get; set; }
        public string PortOfOrigin { get; set; }
        public string PortDestination { get; set; }
        public int CurrencyId { get; set; }
        public int IncotermId { get; set; }
        public int OrderStatusId { get; set; }
        public List<OrderLineDto>? OrderLines { get; set; }

    }
}
