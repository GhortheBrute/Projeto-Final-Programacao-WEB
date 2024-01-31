using Application.Services;
using Domain.Requests;
using Microsoft.AspNetCore.Mvc;
using Web.Filters;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
[CustomActionFilter]
[ExceptionFilter]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;

    public ProductController(IProductService service) { _service = service; }

    [HttpGet]
    public IActionResult List([FromQuery] ProductFilters filters)
    {
        var products = _service.List();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var product = _service.GetById(id);
        return product is null ? NotFound() : Ok(product);
    }

    [HttpPost]
    public IActionResult Post([FromBody] BaseProductRequest product)
    {
        var newProduct = _service.Create(product);
        return Ok(newProduct);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UpdateProductRequest product)
    {
        product.Id = id;
        var updatedProduct = _service.Update(product);
        return Ok(updatedProduct);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.Delete(id);
        return NoContent();
    }
}

public class ProductFilters
{
    public string? Description { get; set; }
    public string? Price { get; set; }
    public string? OrderBy { get; set; }
}

