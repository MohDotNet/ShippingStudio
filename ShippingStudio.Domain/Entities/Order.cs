using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingStudio.Domain.Entities
{

    public class Order
    {
        [Required]
        public int Id { get; set; }
        
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

        public DateTime OrderDate { get; set; }

        [MaxLength(50)]
        public string IndentNumber { get; set; }
        
        [MaxLength(50)]
        public string InternalOrderReference { get; set; }

        [MaxLength(50)]
        public string SupplierOrderReference { get; set; }

        [MaxLength(100)]
        public string PortOfOrigin { get; set; }

        [MaxLength(100)]
        public string PortDestination { get; set; }
        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
        public int IncotermId { get; set; }
        public virtual Incoterm Incoterm { get; set; }
        public int OrderStatus { get; set; }

    }
}
