using Microsoft.AspNetCore.Mvc;
using ProductInventory.Api.Data;
using ProductInventory.Api.Data.DTOs;
using ProductInventory.Api.Models.Products;
using ProductInventory.Api.Models.Responses;
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

    /*
        [HttpPost]   // Create a product Usigng HttpPost Anotation
        public ActionResult CreateProduct([FromBody] Products products)
        {
            // ArgumentNullException.ThrowIfNull(products);
            Products newProduct = _productService.AddProduct(products);
            return Ok(newProduct);
        }

        */
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
    {
        var result = await _productService.CreateProduct(request);
        if (result == null)
        {
            return BadRequest(new ApiResponse<ProductDto>(false, "Product Creation Failed", null));
        }
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, new ApiResponse<ProductDto>(true, "Product Created Successfully", result));
    }

    // Get List of Products
    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var result = await _productService.GetAll();
        return Ok(new ApiResponse<IEnumerable<ProductDto>>(true, "Products Fetched Successfully", result));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _productService.GetById(id);
        if (result == null)
        {
            return NotFound(new ApiResponse<ProductDto>(false, "Product Not Found", null));
        }
        return Ok(new ApiResponse<ProductDto>(true, "Product Fetch Successfully", result));
    }

    /*
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

*/

}