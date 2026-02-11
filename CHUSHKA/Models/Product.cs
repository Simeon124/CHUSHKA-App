using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CHUSHKA.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }

        public ProductType Type { get; set; }

        public bool isDeleted { get; set; }
    }

    public enum ProductType
    {
        Food,
        Domestic,
        Health,
        Cosmetic,
        Other
    }
}
