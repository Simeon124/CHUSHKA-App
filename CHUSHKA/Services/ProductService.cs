using CHUSHKA.Data;
using CHUSHKA.Models;
using Microsoft.EntityFrameworkCore;

namespace CHUSHKA.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext context;

        public ProductService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task CreateAsync(Product newProduct)
        {
            await context.products.AddAsync(newProduct);
            context.SaveChanges();
        }

        public void DeleteById(Guid id)
        {
            context.products.Find(id)!.isDeleted = true;
            context.SaveChanges();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await context.products.FindAsync(id);
        }

        public async Task<List<Product>> ListAllAsync()
        {
            return await context.products.ToListAsync();
        }

        public void Update(Product edit)
        {
            var choosenProduct = context.products.ToList().FirstOrDefault(x => x.Id == edit.Id);

            choosenProduct!.Name = edit.Name;
            choosenProduct.Price = edit.Price;
            choosenProduct.Description = edit.Description;
            choosenProduct.Type = edit.Type;
            context.SaveChanges();
        }
    }
}
