using Microsoft.AspNetCore.Mvc;

using ProductInventory.Api.Models.Products;
using ProductInventory.Api.Services;

namespace ProductInventory.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IproductService _productService; //Create a Variable for the Product Services Interface


    public ProductController(IproductService productServices)
    {
        _productService = productServices;    //Create a productServices variable without creating Object
    }

    [HttpPost]   // Create a product Usigng HttpPost Anotation
    public ActionResult CreateProduct([FromBody] Products products)
    {
        // ArgumentNullException.ThrowIfNull(products);
        Products newProduct = _productService.AddProduct(products);
        return Ok(newProduct);
    }

    [HttpGet("{id}")] //Get the Produt by 'Id'
    // http://localhost:50345/Product/1
    public ActionResult GetProducts(string id)
    {
        Products product = _productService.GetProduct(id);
        return Ok(product);
    }

[HttpGet]
    public ActionResult GetAllProducts()
    {
        var product = _productService.GetAllProducts();
        return Ok(product);
    }

    [HttpPut("{id}")] //Update the product Details
    public ActionResult UpdateProduct(string id,[FromBody] Products products)
    {
        Products product1 = _productService.UpdateProduct(id, products);
        return Ok(product1);
    }


 [HttpDelete("{id}")] //Get the Produt by 'Id'
    // http://localhost:50345/Product/1
    public ActionResult DeleteProduct(string id)
    {
        _productService.DeleteProduct(id);
        return NoContent();
    }

}