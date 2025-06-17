namespace ProductInventory.Api.Services;

using ProductInventory.Api.Models.Products;

public interface IproductService
{
    public Products GetProduct(String id);

    public Products AddProduct(Products products);

    public List<Products> GetAllProducts();

    public void DeleteProduct(string id);

    public Products UpdateProduct(string id,Products products);
}