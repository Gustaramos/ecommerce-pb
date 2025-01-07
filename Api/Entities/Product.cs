namespace ECommerceApp.Entities;

public class Product : BaseEntity
{
    public required string Name { get; set; }
    public required string  Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}