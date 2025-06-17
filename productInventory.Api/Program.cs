using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProductInventory.Api.Data;
using ProductInventory.Api.Repositories;
using ProductInventory.Api.Services;

var builder = WebApplication.CreateBuilder(args);



// Connect DataBase
builder.Services.AddDbContext<ApplicationDbContext>(
    Options=>Options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IproductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

}

app.MapControllers();


app.Run();