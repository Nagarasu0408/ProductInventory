using ProductInventory.Api.Models.Products;
using ProductInventory.Api.Repositories;
using ProductInventory.Api.Services;

namespace ProductInventory.Api.Services;


public class ProductService : IproductService

{

    private IProductRepository _ProductRepositor;

    public ProductService(IProductRepository productRepository)
    {
        _ProductRepositor = productRepository;
    }





    public Products AddProduct(Products products)
    {
        throw new NotImplementedException();
        return _ProductRepositor.Save(products);
    }

    public void DeleteProduct(string id)
    {
        throw new NotImplementedException();

        Products products = _ProductRepositor.Get(id);

        if (products == null)
        {
            // throw new RespurceNotFound();
        }
        _ProductRepositor.RemoveProduct(id);
    }

    public List<Products> GetAllProducts(string id)
    {return _ProductRepositor.GetAll();
    }

    public List<Products> GetAllProducts()
    {
        throw new NotImplementedException();
    }

    public Products GetProduct(string id)
    {
        throw new NotImplementedException();
    }



    public Products UpdateProduct(string id, Products products)
    {
        throw new NotImplementedException();
        Products dbProduct = _ProductRepositor.Get(id);
        if (dbProduct == null)
        {
            // throw new ResourceNotFoundException();
        }
        if (products.Name != "")
        {
            dbProduct.Name = products.Name;
        }
        _ProductRepositor.Save(dbProduct);
    }

    public Products UpdateProduct(Products products)
    {
        throw new NotImplementedException();
    }
}