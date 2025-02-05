using ECommerceApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceApp.Configurations;

public class AttachmentProductConfiguration : IEntityTypeConfiguration<AttachmentProduct>
{
    public void Configure(EntityTypeBuilder<AttachmentProduct> builder)
    {
        builder.HasKey(a => a.Id);

        builder
            .Property(a => a.Id)
            .ValueGeneratedNever();

        builder
            .HasOne(a => a.Product)
            .WithMany(p => p.AttachmentProducts)
            .HasForeignKey(a => a.ProductId);

        builder
            .HasOne(a => a.Attachment)
            .WithOne(b => b.AttachmentProduct)
            .HasForeignKey<AttachmentProduct>(a => a.AttachmentId);
        
        builder.ToTable("AttachmentProduct", "product");
    }
}