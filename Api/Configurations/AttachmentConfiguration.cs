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
            .HasColumnName("Id")
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
            .HasMaxLength(100)
            .IsRequired();
        
        builder
            .Property(a => a.Size)
            .HasColumnName("Size")
            .IsRequired();

        builder
            .HasOne(a => a.AttachmentProduct)
            .WithOne(b => b.Attachment)
            .HasForeignKey<AttachmentProduct>(b => b.AttachmentId);
        
        builder.ToTable("Attachment", "product");
    }
}