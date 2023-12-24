using ShippingStudio.Domain.DTO;
using ShippingStudio.Domain.Entities;
using ShippingStudio.Domain.Enums;
using ShippingStudio.Domain.Interfaces.Repository;
using ShippingStudio.Domain.Models.ResponseModels;
using System.Reflection.Metadata;

namespace ShippingStudio.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ShippingDbContext _context;

        public OrderRepository(ShippingDbContext context)
        {
            _context = context;
        }

        public BaseResponseModel Add(OrderDto order)
        {
            var response = new BaseResponseModel(); 

            if (order == null) 
                return new BaseResponseModel { Code = 1, Message = "Order object is null" };

            try
            {

                List<OrderLines> orderLines = new List<OrderLines>();

                if (order.OrderLines.Count < 1 || order.OrderLines is null)
                {
                    response.Code = 1;
                    response.Message = "Order cannot be created, Order Lines cannot be null or you require at least one order line.";

                    return response;
                 
                }

                foreach (var item in order.OrderLines)
                {
                    orderLines.Add(new OrderLines
                    {
                        Price = item.Price,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        LineTotal = item.LineTotal,
                        LineStatusId = (int)LineStatusEnum.New
                    });
                }

                var _order = new Order
                {
                    CurrencyId = order.CurrencyId,
                    IndentNumber = order.IndentNumber,
                    OrderDate = order.OrderDate,
                    OrderStatusId = order.OrderStatusId,
                    PortOfOrigin = order.PortOfOrigin,
                    PortDestination = order.PortDestination,
                    SupplierId = order.SupplierId,
                    SupplierOrderReference = order.SupplierOrderReference,
                    IncotermId = order.IncotermId,
                    InternalOrderReference = order.InternalOrderReference,
                    OrderLines = orderLines
                  
                };


                _context.Orders.Add(_order);
                _context.SaveChanges();
                response.Code = 0;
                response.Message = "Order has been created successfully....";
            }
            catch (Exception ex)
            {
                response.Code = 1;
                response.Message = ex.Message;
            }

            return response;
        }

        public List<Order> GetAll()
        {
            return _context.Orders.ToList();    
        }

        public Order? GetOrder(int id)
        {
            return _context.Orders.Find(id);
        }

        public Order? GetOrder(string IndentNumber)
        {
            return _context.Orders.Where(x => x.IndentNumber == IndentNumber).FirstOrDefault();
        }

        public BaseResponseModel Update(Order order)
        {
            if (order == null) return new BaseResponseModel { Code = 1, Message = "Object cannot be null to perform an update" };

            var response = new BaseResponseModel();
            
            Order? originalRecord = _context.Orders.Find(order.Id);
            if (originalRecord is null) return new BaseResponseModel { Code = 2, Message = "Record to update cannot be found..." };

            originalRecord.SupplierId = order.SupplierId;
            originalRecord.OrderDate = order.OrderDate;
            originalRecord.IndentNumber = order.IndentNumber;
            originalRecord.InternalOrderReference = order.InternalOrderReference;
            originalRecord.SupplierOrderReference = order.SupplierOrderReference;
            originalRecord.PortOfOrigin = order.PortOfOrigin;
            originalRecord.PortDestination = order.PortDestination;
            originalRecord.CurrencyId = order.CurrencyId;
            originalRecord.IncotermId = order.IncotermId;
            originalRecord.OrderStatus = order.OrderStatus;

            _context.Entry(originalRecord).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            response.Code = 0;
            response.Message = "Order has been updated succcessfully...";

            return response;

    }
    }
}
