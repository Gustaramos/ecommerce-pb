using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        /*
        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        */
    }
}