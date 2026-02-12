using CHUSHKA.Models;

namespace CHUSHKA.Services
{
    public interface IOrderService
    {
        Task CreateAsync(Order newOrder);
        Task<List<Order>> ListAllAsync();
        Task<Order> GetByIdAsync(Guid id);
        void Update(Order edit);
        void DeleteById(Guid id);

    }
}
