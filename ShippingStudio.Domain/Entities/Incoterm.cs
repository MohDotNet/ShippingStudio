﻿using System.ComponentModel.DataAnnotations;

namespace ShippingStudio.Domain.Entities
{
    public class Incoterm
    {

        [Required]
        public int Id { get; set; }

        [MaxLength(100)]
        public string InctermName { get; set; }

    }
}