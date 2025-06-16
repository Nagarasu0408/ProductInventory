namespace ProductInventory.Api.Models.Products;


public class Products
{
    public  string Id { get; set; }
    public  string Name { get; set; }

    public int Quantity { get; set; }

    public double Price { get; set; }

    public Products()
    {

    }

    public Products(string id, string name, int quantity, double price)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
        Price = price;
    }
    
}