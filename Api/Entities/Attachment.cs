namespace ECommerceApp.Entities;

public class Attachment : BaseEntity
{
    public Guid AttachmentProductId { get; set; }
    public Guid Key { get; set; }
    public string ContentType { get; set; }
    public string FileName { get; set; }
    public long Size { get; set; }
    
    public AttachmentProduct? AttachmentProduct { get; set; }

    public Attachment(
        Guid attachmentProductId,
        Guid key,
        string contentType,
        string fileName,
        long size)
    {
        AttachmentProductId = attachmentProductId;
        Key = key;
        ContentType = contentType;
        FileName = fileName;
        Size = size;
    }
}