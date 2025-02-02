using ECommerceApp.Data;
using ECommerceApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Services
{
    //TODO: Refatorar para utilizar o padrao repository
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }
        
        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }
    }
}