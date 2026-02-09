using CHUSHKA.Data;
using CHUSHKA.Models;
using Microsoft.EntityFrameworkCore;

namespace CHUSHKA.Services
{
    public class ProductService : IProductService
    {
        ApplicationDbContext context;
        public async Task Create(Product newProduct)
        {
            await context.products.AddAsync(newProduct);
        }

        public void DeleteById(Guid id)
        {
            context.products.Find(id)!.isDeleted = true;
        }

        public async Task<Product> GetById(Guid id)
        {
            return await context.products.FindAsync(id);
        }

        public async Task<List<Product>> ListAll()
        {
            return await context.products.ToListAsync();
        }

        public void Update(Product edit)
        {
            context.products.Update(edit);
        }
    }
}
