using CHUSHKA.Models;

namespace CHUSHKA.Services
{
    public interface IProductService
    {
        Task Create(Product newProduct);
        Task<List<Product>> ListAll();
        Task<Product> GetById(Guid id);
        void Update(Product edit);
        void DeleteById(Guid id);
    }
}
