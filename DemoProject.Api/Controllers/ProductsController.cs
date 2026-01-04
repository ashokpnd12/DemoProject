using DemoProject.Application.Services;
using DemoProject.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DemoProject.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductService _productService;
    public ProductsController(ProductService productService)
    {
        _productService = productService;
    }
    // GET api/values
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _productService.GetProductsAsync();
        return Ok(products);
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductByIdAsync(int id)
    {
        var products=await _productService.GetProductsByIdAsync(id);
        return Ok(products);
    }

    // POST api/values
    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] Product product)
    {
        if (product == null)
        {
            return BadRequest("Product is null");
        }
        var updatedProduct=await _productService.AddProductAsync(product);
        if (updatedProduct == null)
        {
            return NotFound("Product is null"); ;
        }
        return Ok(updatedProduct);
    }

    // PUT api/values/5
    [HttpPut]
    public async Task<IActionResult> UpdateProductAsync([FromBody] Product product)
    {
        if (product == null)
        {
            return BadRequest("Product is null");
        }
        var existingProduct = await _productService.UpdateProductSync(product);
        if(existingProduct == null)
        {
            return NotFound("Product not found");
        }
        return Ok(existingProduct);
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        bool success = await _productService.DeleteProductAsync(id);
        if (!success)
            return NotFound("Product not found");
        return NoContent();
    }
}