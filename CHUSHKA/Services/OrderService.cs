using CHUSHKA.Data;
using CHUSHKA.Models;
using Microsoft.EntityFrameworkCore;

namespace CHUSHKA.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext context;

        public OrderService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task CreateAsync(Order newOrder)
        {
            await context.orders.AddAsync(newOrder);
            context.SaveChanges();
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            return await context.orders.FindAsync(id)!;
        }

        public async Task<List<Order>> ListAllAsync()
        {
            return await context.orders.Include(o => o.Product).Include(o => o.Client).ToListAsync();
        }

        public void Update(Order edit)
        {
            var choosenOrder = context.orders.FirstOrDefault(x => x.Id == edit.Id);

            choosenOrder!.Client = edit.Client;
            choosenOrder.Product = edit.Product;
            context.SaveChanges();
        }

        public void DeleteById(Guid id)
        {
            context.orders.Find(id)!.isDeleted = true;
            context.SaveChanges();
        }
    }
}
