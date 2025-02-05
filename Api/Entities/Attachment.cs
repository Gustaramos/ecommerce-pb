namespace ECommerceApp.Entities;

public class Attachment : BaseEntity
{
    public Guid Key { get; set; }
    public string ContentType { get; set; }
    public string FileName { get; set; }
    public long Size { get; set; }
    
    public Product Product { get; set; }

    public Attachment(
        Guid key,
        string contentType,
        string fileName,
        long size)
    {
        Key = key;
        ContentType = contentType;
        FileName = fileName;
        Size = size;
    }
}