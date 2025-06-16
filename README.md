
# 🧾 Product Inventory API - Project Explanation

This document explains the structure and logic of the `productInventory.Api` backend built using ASP.NET Core Web API and MVC pattern

### 1. Create a Solution File

``` csharp
1. dotnet new sln -n ProductInventorySolution
```

      Creates a new **solution file** (`.sln`) named `ProductInventorySolution.sln`.
      
Why it's used:  
		A solution groups multiple related projects — useful for organizing your app (e.g., API, tests, services) under one logical unit.
		
**Impact:**  
		This acts like a master container for your whole project, making it easier to manage builds, run tests, and collaborate using tools like Visual Studio or VS Code.


### 2. Creates a new ASP.NET Core Web API project
```CSharp
2. dotnet new webapi -n productInventory.Api
```

 ```c

## What it does:
Creates a new ASP.NET Core Web API project named `productInventory.Api`.

# Why it's used:  
This is your **main application** — it will contain controllers, routes, services, models, etc., to handle HTTP requests and respond with data (like JSON).

# Impact: 
This is the **core of your backend** — where RESTful endpoints like `GET /products` or `POST /products` will live.

📦 Output: Creates files like:

- `Program.cs`, `Startup.cs` (or just `Program.cs` in .NET 6+)
    
- `Controllers/WeatherForecastController.cs`
    
- `appsettings.json`

```


### 3. Creates a new **xUnit** test

```csharp
3. dotnet new xunit -n productInventory.Tests
```


``` c
To write unit tests for your API — ensures that your code behaves as expected.

# Impact:  
Helps in Test-Driven Development (TDD) and improves code reliability. You’ll test your API controllers, services, and models here.
```


### 4. Adds the **API project** (`.csproj`) to the **solution file**.

```Csharp
4. dotnet sln add productInventory.Api/ productInventory.Api.csproj
```

```c
Links the project to your main solution so the solution knows it exists and can build it.

# Impact: 
Allows easy building/running/testing from the solution level and helps when working in IDEs (e.g., Visual Studio shows everything in one place).
```


### 5.Adds the **test project** to the same solution.

```csharp
5. dotnet sln add productInventory.Tests/ productInventory.Tests.csproj
```

```c
Same as above — it connects the unit test project to the solution.

# Impact:  
Keeps testing organized under the same solution umbrella.

```


#### 6. Creates a **project reference** from `productInventory.Tests` → `productInventory.Api`.

```csharp
6. dotnet add productInventory.Tests reference productInventory.Api
```

```c
So that the test project can **access the classes and methods** in the API project (e.g., controllers, services) for testing.

# Impact:  
Without this reference, your tests won’t be able to call methods from the API project. This makes cross-project access possible for testing.
```

### Summary of Architecture:

|Project|Type|Purpose|
|---|---|---|
|`ProductInventorySolution.sln`|Solution|Links everything together|
|`productInventory.Api`|Web API|Main backend service|
|`productInventory.Tests`|xUnit|Unit testing project|


## 📁 Project Structure

```csharp
productInventory.Api/
│
├── Controllers/
│   └── ProductController.cs
│
├── Models/
│   └── Product.cs
│
├── Repositories/
│   ├── IProductRepository.cs
│   └── ProductRepository.cs
│
├── Services/
│   ├── IProductService.cs
│   └── ProductService.cs
│
├── Program.cs
├── productInventory.Api.csproj

```


## ✅ Summary

| Layer      | Responsibility                  |
| ---------- | ------------------------------- |
| Model      | Represents product data.        |
| Repository | Handles data storage/retrieval. |
| Service    | Contains business logic.        |
| Controller | Handles API endpoints.          |


## 📌 Project Flow

1. **Client** sends request to `ProductController`.
2. `ProductController` calls `ProductService`.
3. `ProductService` calls `ProductRepository`.
4. `ProductRepository` reads/writes in-memory product list.



## Main File

### Program.cs 

```csharp
// Required namespaces for building and running the app
using productInventory.Api.Repositories;
using productInventory.Api.Services;

var builder = WebApplication.CreateBuilder(args); // Creates the web app builder

// ----------------------
// 1. Add services to the DI container
// ----------------------
builder.Services.AddControllers(); // Adds support for API controllers
builder.Services.AddEndpointsApiExplorer(); // Enables minimal APIs and Swagger
builder.Services.AddSwaggerGen(); // Adds Swagger (OpenAPI) for documentation

// Registering dependencies for DI
builder.Services.AddScoped<IProductRepository, ProductRepository>(); // Repository binding
builder.Services.AddScoped<IProductService, ProductService>();       // Service binding

// ----------------------
// 2. Build the app
// ----------------------
var app = builder.Build(); // Builds the app pipeline

// ----------------------
// 3. Configure the HTTP request pipeline
// ----------------------
if (app.Environment.IsDevelopment()) // Show Swagger only in development mode
{
    app.UseSwagger();             // Enable Swagger middleware
    app.UseSwaggerUI();           // Show Swagger UI at /swagger
}

app.UseHttpsRedirection(); // Redirect HTTP to HTTPS

app.UseAuthorization(); // Enable authorization (can be customized)

app.MapControllers(); // Map controller endpoints like /api/product

app.Run(); // Run the application


```


#### Explanation

|Part|Purpose|
|---|---|
|`builder.Services.AddControllers()`|Tells ASP.NET Core to use MVC-style API controllers.|
|`AddScoped<IProductService, ProductService>()`|Registers your service logic for DI.|
|`AddScoped<IProductRepository, ProductRepository>()`|Registers your data repository.|
|`UseSwagger()` & `UseSwaggerUI()`|Enables interactive API docs at `/swagger`.|
|`app.MapControllers()`|Maps endpoints from controller routes like `/api/product`.|
|`app.Run()`|Starts the application.|

---
