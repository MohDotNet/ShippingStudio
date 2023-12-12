using ShippingStudio.Domain.Entities;
using ShippingStudio.Domain.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingStudio.Domain.Interfaces.Repository
{
    public interface IOrderLinesRepository
    {

        List<OrderLines> GetOrderLines();

        List<OrderLines> GetOrderLines(int orderId);

        BaseResponseModel AddLine(OrderLines orderLines);
        BaseResponseModel Update(OrderLines orderLines);
        
    }
}
