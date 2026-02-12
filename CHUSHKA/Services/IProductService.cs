using CHUSHKA.Models;

namespace CHUSHKA.Services
{
    public interface IProductService
    {
        Task CreateAsync(Product newProduct);
        Task<List<Product>> ListAllAsync();
        Task<Product> GetByIdAsync(Guid id);
        void Update(Product edit);
        void DeleteById(Guid id);
    }
}
