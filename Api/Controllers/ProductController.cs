using ECommerceApp.Entities;
using ECommerceApp.Models;
using ECommerceApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

//TODO: Refatorar o processo de acoes do banco com base em um model nao entity
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
    
    [HttpPost]
    public async Task<IActionResult> AddAsync(
        [FromForm] ProductModel product,
        CancellationToken cancellationToken)
    {
        await _productService.AddAsync(product, cancellationToken);
        //TODO: definir o que ira retornar
        return Ok(product);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] Product product, CancellationToken cancellationToken)
    {
        await _productService.UpdateAsync(product, cancellationToken);
        return Ok();
    }
}