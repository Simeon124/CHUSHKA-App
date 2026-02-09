using CHUSHKA.Data;
using CHUSHKA.Models;
using Microsoft.EntityFrameworkCore;

namespace CHUSHKA.Services
{
    public class OrderService : IOrderService
    {
        ApplicationDbContext context;
        public async Task Create(Order newOrder)
        {
            await context.orders.AddAsync(newOrder);
        }

        public async Task<Order> GetById(Guid id)
        {
            return await context.orders.FindAsync(id);
        }

        public async Task<List<Order>> ListAll()
        {
            return await context.orders.ToListAsync();
        }

        public void Update(Order edit)
        {
            context.orders.Update(edit);
        }

        public void DeleteById(Guid id)
        {
            context.orders.Find(id)!.isDeleted = true;
        }
    }
}
