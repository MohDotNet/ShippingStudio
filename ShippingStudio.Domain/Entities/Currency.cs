using System.ComponentModel.DataAnnotations;

namespace ShippingStudio.Domain.Entities
{
    public class Currency
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string CurrencyName { get; set; }

        [Required]
        [MaxLength(5)]
        public string CurrencyCode { get; set; }
        public bool IsDisabled { get; set; }
    }
}