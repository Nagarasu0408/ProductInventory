using System.ComponentModel.Design;
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
        return _ProductRepositor.Save(products);
    }

    public void DeleteProduct(string id)
    {
        Products products = _ProductRepositor.Get(id);

        if (products == null)
        {
            // throw new RespurceNotFound();
            throw new Exception();
        }
        _ProductRepositor.RemoveProduct(id);
    }
    public List<Products> GetAllProducts()
    {
        return _ProductRepositor.GetAll();
    }

    public Products GetProduct(string id)
    {
        return _ProductRepositor.Get(id);   
    }



    public Products UpdateProduct(string id, Products products)
    {
        Products dbProduct = _ProductRepositor.Get(id);
        if (dbProduct == null)
        {
            // throw new ResourceNotFoundException();
            throw new Exception();
        }
        if (products.Name != "")
        {
            dbProduct.Name = products.Name;
        }

        Products updatedProduct = _ProductRepositor.Save(dbProduct);
        _ProductRepositor.Save(updatedProduct);

        return updatedProduct;
    }

    public Products UpdateProduct(Products products)
    {
        throw new NotImplementedException();
    }
}