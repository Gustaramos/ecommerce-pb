using ECommerceApp.Entities;
using ECommerceApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(
        IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _productService.GetAllAsync());
    }
    
    //TODO: Refatorar o processo de insert para inserir com base em um model nao entity
    [HttpPost]
    public async Task<IActionResult> AddAsync(
        [FromBody] Product product)
    {
        await _productService.AddAsync(product);
        return Ok();
    }
}