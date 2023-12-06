using System.ComponentModel.DataAnnotations;

namespace ShippingStudio.Domain.Entities
{
    public class Product
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        public bool IsDisabled { get; set; }

    }
}