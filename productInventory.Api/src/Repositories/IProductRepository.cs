using ProductInventory.Api.Models.Products;

namespace ProductInventory.Api.Repositories;


public interface IProductRepository
{
    public Products Save(Products product);


    public List<Products> GetAll();

    public Products Get(string id);

    public Products UpdateProduct(string id,Products product);

    public void RemoveProduct(string id);
}