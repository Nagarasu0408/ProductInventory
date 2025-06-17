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










/*

What is ORM?

The full form of ORM framework is Object-Relational Mapping. 
It's a programming technique that simplifies the interaction 
between object-oriented programming languages and relational databases.
ORM tools automate the process of translating objects in an OOP language 
into tables in a relational database, reducing the need for manual SQL queries




*/