using Microsoft.EntityFrameworkCore;
using ProductInventory.Api.Models.Products;

namespace ProductInventory.Api.Data;


public class ApplicationDbContext : DbContext
{
    public DbSet<Products> products { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

}