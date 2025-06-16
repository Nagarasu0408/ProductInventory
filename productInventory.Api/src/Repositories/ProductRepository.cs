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
        throw new NotImplementedException();
        var product = ListOfProduct.Find(e => e.Id == id);
        return product;
    }

    public List<Products> GetAll()
    {
        throw new NotImplementedException();
    }

    public Products RemoveProduct(string id)
    {
        throw new NotImplementedException();
    }

    public Products Save(Products product)
    {
        throw new NotImplementedException();
    }

    public Products UpdateProduct(Products product)
    {
        throw new NotImplementedException();
    }
}