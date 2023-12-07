using Microsoft.Identity.Client;
using ShippingStudio.Domain.Entities;
using ShippingStudio.Domain.Interfaces.Repository;
using ShippingStudio.Domain.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingStudio.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ShippingDbContext _context;

        public OrderRepository(ShippingDbContext context)
        {
            _context = context;
        }

        public BaseResponseModel Add(Order order)
        {
            var response = new BaseResponseModel(); 

            if (order == null) 
                return new BaseResponseModel { Code = 1, Message = "Order object is null" };

            try
            {
                _context.Orders.Add(order);
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
