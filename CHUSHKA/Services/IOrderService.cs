using CHUSHKA.Models;

namespace CHUSHKA.Services
{
    public interface IOrderService
    {
        Task Create(Order newOrder);
        Task<List<Order>> ListAll();
        Task<Order> GetById(Guid id);
        void Update(Order edit);
        void DeleteById(Guid id);

    }
}
