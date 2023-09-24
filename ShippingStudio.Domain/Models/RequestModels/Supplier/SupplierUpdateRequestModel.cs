using ShippingStudio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingStudio.Domain.Models.RequestModels.Supplier
{
    public class SupplierUpdateRequestModel
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string TelephoneNumebr { get; set; }
        public int DefaultCurrency { get; set; }
        public int ShippingPortId { get; set; }

    }
}
