using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingStudio.Domain.Entities
{
    public class FileStatuses
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
    }
}
