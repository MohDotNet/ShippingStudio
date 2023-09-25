using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingStudio.Domain.Entities
{
    public class Filing
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Filename { get; set; }

        [MaxLength(50)]
        public string FileCode { get; set; }
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

    }
}
