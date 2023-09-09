using System.ComponentModel.DataAnnotations;

namespace ShippingStudio.Domain.Entities
{
    public class ShippingPort
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Port { get; set; }

        [Required]
        [MaxLength(100)]
        public string Country { get; set; }
        public bool IsDisabled { get; set; }

    }
}