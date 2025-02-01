using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.Entities;

namespace ECommerceApp.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();
    }
}