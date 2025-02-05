namespace ECommerceApp.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public void SetCreatedAt(DateTime createdAt)
    {
        CreatedAt = createdAt;
    }

    public void SetUpdatedAt(DateTime updatedAt)
    {
        UpdatedAt = updatedAt;
    }
}