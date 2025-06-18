namespace ProductInventory.Api.Services;

using System.Threading.Tasks;
using ProductInventory.Api.Data;
using ProductInventory.Api.Data.DTOs;
using ProductInventory.Api.Models.Products;
using ProductInventory.Api.Models.Requests;

public interface IproductService
{
    // public Products GetProduct(String id);
    // public Products AddProduct(Products products);
    // public List<Products> GetAllProducts();
    // public void DeleteProduct(string id);
    // public Products UpdateProduct(string id,Products products);
    // Task<ProductDto> AddProduct(CreateProductRequest request);

    Task<ProductDto> CreateProduct(CreateProductRequest createProduct);
    Task<IEnumerable<ProductDto>> GetAll();
    Task<ProductDto> GetById(Guid id);
     Task<ProductDto> UpdateProduct(Guid id, UpdateProductRequest request);
    Task<bool> DeleteProductAsync(Guid id);


    // Task<ProductDto> UpdateProduct(Guid id, UpdateProductRequest request);
    // Task<bool> DeleteProductAsync(Guid id);
}