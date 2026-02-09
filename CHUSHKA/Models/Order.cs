using Microsoft.AspNetCore.Identity;

namespace CHUSHKA.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public IdentityUser Client { get; set; }
        public DateTime OrderedOn { get; set; }
        public bool isDeleted { get; set; }
    }
}
