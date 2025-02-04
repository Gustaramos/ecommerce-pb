namespace ECommerceApp.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string  Description { get; set; }
    public Guid AttachName { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public IEnumerable<Attachment> Attachments { get; set; } = [];

    public Product(
        string name,
        string description,
        Guid attachName,
        decimal price,
        int stock)
    {
        Name = name;
        Description = description;
        AttachName = attachName;
        Price = price;
        Stock = stock;
    }
}