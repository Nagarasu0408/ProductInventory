using Microsoft.EntityFrameworkCore;
using ProductInventory.Api.Data;
using ProductInventory.Api.Models.Products;

namespace ProductInventory.Api.Repositories;


public class ProductRepository : IProductRepository
{

    /*

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
    */

    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Products> AddAsync(Products product)
    {
        await _context.products.AddAsync(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<IEnumerable<Products>> GetProductsAsync()
    {
        return await _context.products.ToListAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var product = await _context.products.FindAsync(id);
        if (product is null)
        {
            return;
        }

        _context.products.Remove(product);
        await _context.SaveChangesAsync();
        return;
    }



    public async Task<Products> GetByIdAsync(Guid id)
    {
        return await _context.products.FindAsync(id)!;
    }

    public async Task UpdateAsync(Products product)
    {
        var existingProduct = await _context.products.FindAsync(product.Id);
        if (existingProduct is null)
        {
            throw new KeyNotFoundException("Product not found");
        }

        _context.Entry(existingProduct).CurrentValues.SetValues(product);
        await _context.SaveChangesAsync();
    }
}