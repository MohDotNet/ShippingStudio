using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingStudio.Domain.Models.ResponseModels.Order
{
    public class OrderResponseModel : BaseResponseModel
    {
        public int OrderId { get; set; }
        public string IndentNo { get; set; }
        public string ReferenceNumber { get; set; }

    }
}
