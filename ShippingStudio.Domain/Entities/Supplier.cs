using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingStudio.Domain.Entities
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Company { get; set; }

        [MaxLength(100)]
        public string ContactPerson { get; set; }

        [MaxLength(250)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string TelephoneNumebr { get; set; }
        
        
        public int DefaultCurrency { get; set; }
        public virtual Currency Currency { get; set; }
        
        public int ShippingPortId { get; set; }
        public virtual ShippingPort ShippingPort { get; set; }



    }
}
