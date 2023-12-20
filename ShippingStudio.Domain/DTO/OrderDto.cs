using ShippingStudio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingStudio.Domain.DTO
{
    public class OrderDto
    {
        public int SupplierId { get; set; }
        public DateTime OrderDate { get; set; }
        public string IndentNumber { get; set; }
        public string InternalOrderReference { get; set; }
        public string SupplierOrderReference { get; set; }
        public string PortOfOrigin { get; set; }
        public string PortDestination { get; set; }
        public int CurrencyId { get; set; }
        public int IncotermId { get; set; }
        public int OrderStatusId { get; set; }
        public List<OrderLineDto>? OrderLines { get; set; }
    }
}
