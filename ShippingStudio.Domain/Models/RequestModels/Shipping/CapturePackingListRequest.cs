using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingStudio.Domain.Models.RequestModels.Shipping
{
    public class CapturePackingListRequest
    {
        public int SupplierId { get; set; }
        public int OrderId { get; set; }
        public int OrderLineId { get; set; }
        public decimal ShipQuantity { get; set; }
        public string WaybillNumber { get; set; }
        public string ContainerNumber { get; set; }
        public int ContainerType { get; set; }
        public DateTime PackedDated { get; set; }

    }
}
