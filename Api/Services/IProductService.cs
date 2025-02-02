using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.Entities;
using ECommerceApp.Models;

namespace ECommerceApp.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task AddAsync(ProductModel product);
        Task UpdateAsync(Product product);
    }
}