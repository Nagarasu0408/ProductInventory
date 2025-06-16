using ProductInventory.Api.Models.Products;

namespace ProductInventory.Api.Repositories;


public interface IProductRepository
{
    public Products Save(Products product);


    public List<Products> GetAll();

    public Products Get(string id);

    public Products UpdateProduct(Products product);

    public Products RemoveProduct(string id);
}