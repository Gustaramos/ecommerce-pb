namespace ECommerceApp.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string  Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public ICollection<AttachmentProduct> AttachmentProducts { get; private set; } = [];

    public Product(
        string name,
        string description,
        decimal price,
        int stock)
    {
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
    }
}