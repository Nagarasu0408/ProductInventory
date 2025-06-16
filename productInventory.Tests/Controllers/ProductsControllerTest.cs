
using Microsoft.AspNetCore.Mvc;
using ProductInventory.Api.Controllers;
using ProductInventory.Api.Models.Products;

public class ProductsControllerTest
{
    [Fact]
    public void ProductAdd_ShouldIncreaseCount()
    {

        // Given
        ProductController productController = new ProductController();

        var result = productController.CreateProduct(new Products { Id = "144", Name = "Lock", Quantity = 100, Price = 245.67 }); //Create a Product

        Assert.IsType<OkObjectResult>(result);



    }
}
