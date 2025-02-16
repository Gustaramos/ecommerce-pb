using ECommerceApp.Entities;
using ECommerceApp.Models;

namespace ECommerceApp.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task AddAsync(ProductModel product, CancellationToken cancellationToken);
        Task UpdateAsync(Product product, CancellationToken cancellationToken);
    }
}