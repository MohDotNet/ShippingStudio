using ShippingStudio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingStudio.Domain.DTO
{
    public class OrderLineDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double LineTotal { get; set; }
        public int TotalShipped { get; set; }
        public int Status { get; set; }
    }
}
