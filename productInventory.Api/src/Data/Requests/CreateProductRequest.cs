namespace ProductInventory.Api.Data;

public class CreateProductRequest
{
    public string? Name { get; set; }
    public double price { get; set; }
    public int Quantity { get; set; }
    public List<Category>? Categories { get; set; }

}