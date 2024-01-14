using ShippingStudio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingStudio.Domain.DTO
{
    public class PackingListDto
    {
        public int SupplierId { get; set; }
        public int OrderId { get; set; }
        public int OrderLineId { get; set; }
        public int ProductId { get; set; }
        public decimal ShipQuantity { get; set; }
        public decimal QuantityCheckedIn { get; set; }
        public string WaybillNumber { get; set; }
        public string ContainerNumber { get; set; }
        public int ContainerType { get; set; }
        public DateTime PackedDated { get; set; }
        public DateTime ShippedDate { get; set; }
        public bool HasDeparted { get; set; }
        public bool HasArrived { get; set; }
        public DateTime ArrivedDate { get; set; }
        public bool HasDelivered { get; set; }
        public DateTime DeliveredDate { get; set; }
        public bool CostingDone { get; set; }
        public DateTime CostingDate { get; set; }
    }
}
