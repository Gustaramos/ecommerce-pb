using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.Models;

namespace ECommerceApp.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        void AddProduct(Product produtc);
    }
}