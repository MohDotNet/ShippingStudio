using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingStudio.Domain.Models.RequestModels.Order
{
    public class ConfirmPurchaseOrderModel
    {
        public string IndentNumber { get; set; }
        public int OrderId { get; set; }

    }
}
