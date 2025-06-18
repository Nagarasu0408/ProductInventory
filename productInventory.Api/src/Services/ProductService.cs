using System.ComponentModel.Design;
using AutoMapper;
using ProductInventory.Api.Data;
using ProductInventory.Api.Data.DTOs;
using ProductInventory.Api.Models.Products;
using ProductInventory.Api.Models.Requests;
using ProductInventory.Api.Repositories;
using ProductInventory.Api.Services;

namespace ProductInventory.Api.Services;


public class ProductService : IproductService

{

    private IProductRepository _ProductRepository;

    private readonly IMapper _mapper; //Mapper Object

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _ProductRepository = productRepository;
        _mapper = mapper;
    }

    // public Products AddProduct(Products products)
    // {
    //     return _ProductRepositor.Save(products);
    // }

    // public List<Products> GetAllProducts()
    // {
    //     return _ProductRepositor.GetAll();
    // }


    // public Products GetProduct(string id)
    // {
    //     return _ProductRepositor.Get(id);
    // }

    public async Task<ProductDto> CreateProduct(CreateProductRequest createProduct)
    {
        var product = _mapper.Map<Products>(createProduct);
        await _ProductRepository.AddAsync(product);
        var productDto = _mapper.Map<ProductDto>(product);
        return productDto;
    }

    public async Task<IEnumerable<ProductDto>> GetAll()
    {
        var products = await _ProductRepository.GetProductsAsync();
        var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
        return productDtos;
    }

    public async Task<ProductDto> GetById(Guid id)
    {
        var product = await _ProductRepository.GetByIdAsync(id);
        var productDto = _mapper.Map<ProductDto>(product);
        return productDto;
    }
 public async Task<ProductDto> UpdateProduct(Guid id, UpdateProductRequest request)
    {
        var product = await _ProductRepository.GetByIdAsync(id);
        if (product == null)
        {
            return null;
        }

        _mapper.Map(request, product);
        await _ProductRepository.UpdateAsync(product);

        var productDto = _mapper.Map<ProductDto>(product);
        return productDto;
    }

    public async Task<bool> DeleteProductAsync(Guid id)
    {
        var product = _ProductRepository.GetByIdAsync(id);
        if(product is null)
        {
            return false;
        }
        await _ProductRepository.DeleteAsync(id);
        return true;

    }

//  public void DeleteProduct(string id)
    //     {
    //         Products products = _ProductRepository.Get(id);

    //         if (products == null)
    //         {
    //             // throw new RespurceNotFound();
    //             throw new Exception();
    //         }
    //         _ProductRepository.RemoveProduct(id);
    //     }


    // public Products UpdateProduct(string id, Products products)
    // {
    //     Products dbProduct = _ProductRepository.Get(id);
    //     if (dbProduct == null)
    //     {
    //         // throw new ResourceNotFoundException();
    //         throw new Exception("Not found");
    //     }
    //     if (products.Name != "")
    //     {
    //         dbProduct.Name = products.Name;
    //     }

    //     Products updatedProduct = _ProductRepository.UpdateProduct(id,dbProduct);
    //     // _ProductRepositor.UpdateProduct(updatedProduct);

    //     return updatedProduct;
    // }
}
