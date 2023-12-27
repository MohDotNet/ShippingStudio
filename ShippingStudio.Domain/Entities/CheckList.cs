using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingStudio.Domain.Entities
{
    public class CheckList
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }


        [MaxLength(50)]
        public string IndentNumber { get; set; }

        [MaxLength(100)]
        public string WaybillNumber { get; set; }

        public bool? PurchaseOrderCreated { get; set; }
        
        [Column(TypeName = "datetime2")]
        public DateTime? PurchaseOrderDate { get; set; }
        public bool? IndentReceived { get; set; }
        public DateTime? IndentReceivedDate { get; set; }
        public bool? PackingListReceived { get; set; }
        public DateTime? PackingListReceiveDate { get; set; }
        public bool? HasShipped { get; set; }
        public DateTime? DateShipped { get; set; }
        public bool? HasArrived  { get; set; }
        public DateTime? DateArrived { get; set; }
        public bool? HasDelivered { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public bool? DoneCosting { get; set; }
        public DateTime? CostingDate { get; set; }
        public bool? RaisedFinance { get; set; }
        public DateTime? FinanceDate { get; set; }
        public bool? HasInsured { get; set; }
        public DateTime? InsuranceDeclarationDate { get; set; }
        public decimal? ExchangeRate { get; set; }
        public int? CurrencyId { get; set; }
        public virtual Currency? Currency { get; set; }

    }
}
