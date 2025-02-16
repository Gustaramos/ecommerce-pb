namespace ECommerceApp.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime UpdatedAt { get; protected set; }

    protected BaseEntity()
    {
        Id = Guid.NewGuid();
    }
    
    public void SetCreatedAt(DateTime createdAt)
    {
        CreatedAt = createdAt;
    }

    public void SetUpdatedAt(DateTime updatedAt)
    {
        UpdatedAt = updatedAt;
    }
}