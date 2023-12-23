using ShippingStudio.Domain.Entities;
using ShippingStudio.Domain.Interfaces.Repository;
using ShippingStudio.Domain.Models.ResponseModels;

namespace ShippingStudio.Data.Repository
{
    public class OrderLineRepository : IOrderLinesRepository
    {
        private readonly ShippingDbContext _context;

        public OrderLineRepository(ShippingDbContext context)
        {
            _context = context;
        }
        public BaseResponseModel AddLine(OrderLines orderLines)
        {
            if (orderLines == null) return new BaseResponseModel { Code = 1, Message = "Order line object cannot be null" };

            _context.OrderLines.Add(orderLines);
            _context.SaveChanges();

            return new BaseResponseModel { Message = "Saved successfully...", Code = 0 };
        }

        public List<OrderLines> GetOrderLines()
        {
            return _context.OrderLines.ToList();
        }

        public List<OrderLines>? GetOrderLines(int orderId)
        {
            return _context.OrderLines.Where(x => x.OrderId == orderId).ToList();
        }

        public BaseResponseModel Update(OrderLines orderLines)
        {
            if (orderLines == null) return new BaseResponseModel { Code = 1, Message = "Order line object cannot be null" };

            var originalLine = _context.OrderLines.Where(x=> x.Id == orderLines.Id).SingleOrDefault();
            var response = new BaseResponseModel();

            if (originalLine != null) 
            {
                originalLine.ProductId = orderLines.ProductId;
                originalLine.Quantity = orderLines.Quantity;
                originalLine.Price = orderLines.Price;
                originalLine.LineTotal = orderLines.LineTotal;
                originalLine.TotalShipped = orderLines.TotalShipped;
                originalLine.LineStatusId = orderLines.LineStatusId;

                _context.SaveChanges();

                response.Code = 0;
                response.Message = "Line has been updated successfully..";
        
            }
            else
            {
                response.Code = 2;
                response.Message = "Record could not be found, and have not been updated.";
            }

            return response;
        }

    }
}
