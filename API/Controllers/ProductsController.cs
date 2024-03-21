using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ProductsController : BaseApiController
{
    private readonly IProductRepository _productRepository;

    public ProductsController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductCardDto>>> GetProducts()
    {
        var products = await _productRepository.GetProductsAsync();
        return Ok(products);
    }
}
