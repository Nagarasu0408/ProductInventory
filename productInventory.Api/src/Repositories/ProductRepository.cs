using ProductInventory.Api.Data;
using ProductInventory.Api.Models.Products;

namespace ProductInventory.Api.Repositories;


public class ProductRepository : IProductRepository
{


    // List<Products> ListOfProduct;
    // public ProductRepository()
    // {
    //     ListOfProduct = new List<Products>();
    // }

    public ApplicationDbContext _applicationDbContext;

    public ProductRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
        
    }



    public Products Get(string id)
    {

        // var product = _applicationDbContext.products.Find(e => e.Id == id);
        Products products = _applicationDbContext.products.Find(id);
        return products;
    }

    public List<Products> GetAll()
    {
        return _applicationDbContext.products.ToList<Products>();
    }

    public void RemoveProduct(string id)
    {
        // var product = _applicationDbContext.products.Find(e => e.Id == id);
        Products product = _applicationDbContext.products.Find(id);
        _applicationDbContext.products.Remove(product);
        _applicationDbContext.SaveChanges();

    }

    public Products Save(Products product)
    {
        _applicationDbContext.products.Add(product);
        _applicationDbContext.SaveChanges();
        return product;
    }

    public Products UpdateProduct(string id,Products product)
    {
        _applicationDbContext.products.Update(product);
        _applicationDbContext.SaveChanges();
        return product;
    }
}