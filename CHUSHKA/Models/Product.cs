using Microsoft.AspNetCore.Identity;

namespace CHUSHKA.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
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
