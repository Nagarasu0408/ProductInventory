using ProductInventory.Api.Models.Products;

namespace ProductInventory.Api.Repositories;


public class ProductRepository : IProductRepository
{


    List<Products> ListOfProduct;
    public ProductRepository()
    {
        ListOfProduct = new List<Products>();
    }
    public Products Get(string id)
    {
        
        var product = ListOfProduct.Find(e => e.Id == id);
        return product;
    }

    public List<Products> GetAll()
    {
        return ListOfProduct;
    }

    public void RemoveProduct(string id)
    {
        var product = ListOfProduct.Find(e => e.Id == id);
        ListOfProduct.Remove(product);

    }

    public Products Save(Products product)
    {
        ListOfProduct.Add(product);
        return product;
    }

    public Products UpdateProduct(Products product)
    {
        ListOfProduct.Add(product);
        return product;
    }
}