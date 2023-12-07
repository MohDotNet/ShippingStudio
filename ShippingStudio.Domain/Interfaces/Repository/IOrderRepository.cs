using ShippingStudio.Domain.Entities;
using ShippingStudio.Domain.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingStudio.Domain.Interfaces.Repository
{
    public interface IOrderRepository
    {
        BaseResponseModel Add(Order order);
        List<Order> GetAll();   
        Order GetOrder(int id);
        Order GetOrder(string IndentNumber);
        BaseResponseModel Update(Order order);

    }
}
