using ECommerceApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceApp.Configurations;

public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
{
    public void Configure(EntityTypeBuilder<Attachment> builder)
    {
        builder.HasKey(a => a.Id);

        builder
            .Property(a => a.Id)
            .ValueGeneratedNever();

        builder.Property(a => a.Key)
            .HasColumnName("Key")
            .ValueGeneratedNever();

        builder
            .Property(a => a.FileName)
            .HasColumnName("FileName")
            .HasMaxLength(250)
            .IsRequired();

        builder
            .Property(a => a.ContentType)
            .HasColumnName("ContentType")
            .HasMaxLength(5)
            .IsRequired();
        
        builder
            .Property(a => a.Size)
            .HasColumnName("Size")
            .IsRequired();

        builder
            .HasOne(a => a.AttachmentProduct)
            .WithOne(b => b.Attachment)
            .HasForeignKey<Attachment>(a => a.AttachmentProductId);
        
        builder.ToTable("Attachment", "product");
    }
}