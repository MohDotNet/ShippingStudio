using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ShippingStudio.Domain.Entities
{
    public class OrderLines
    {
        [Required]
        public int Id { get; set; }   
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double LineTotal { get; set; }
        public int TotalShipped { get; set; }
        public int LineStatusId { get; set; }
        public virtual LineStatus LineStatus { get; set; }

        public List<PackingList>? PackingList { get; set; }


    }
}
