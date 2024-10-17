using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Controllers
{
    public class ProductsController : Controller
    {
        private static List<Product> Products = new List<Product> 
        {
            new Product { Id = 1, Name =  "Camiseta", Description = "Oversized", Price = 120, Stock = 20 },
            new Product { Id= 2, Name = "Moletom", Description = "Com touca", Price = 230, Stock = 15}
        };

        //List products
        public IActionResult Index()
        {
            return View(Products);
        }

        //Creating product
        [HttpPost]
        public IActionResult Create (Product product)
        {
            product.Id = Products.Count + 1;
            Products.Add(product);
            return RedirectToAction("Index");
        }

    }
}