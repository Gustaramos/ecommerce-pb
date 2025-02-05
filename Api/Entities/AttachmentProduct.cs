namespace ECommerceApp.Entities;

public class AttachmentProduct : BaseEntity
{
    public Guid ProductId { get; set; }
    public Guid AttachmentId { get; set; }
    
    public Product? Product { get; set; }
    public Attachment? Attachment { get; set; }
}