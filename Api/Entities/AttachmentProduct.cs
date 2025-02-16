namespace ECommerceApp.Entities;

public class AttachmentProduct : BaseEntity
{
    public Guid ProductId { get; set; }
    public Guid AttachmentId { get; set; }
    
    public Product? Product { get; private set; }
    public Attachment? Attachment { get; private set; }

    public AttachmentProduct(
        Guid productId,
        Guid attachmentId)
    {
        ProductId = productId;
        AttachmentId = attachmentId;
    }
}