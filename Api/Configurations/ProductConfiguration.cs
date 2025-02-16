using ECommerceApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceApp.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(b => b.Id);
        
        builder
            .Property(a => a.Id)
            .HasColumnName("Id")
            .ValueGeneratedNever();

        builder
            .Property(b => b.Name)
            .HasColumnName("Name")
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(b => b.Description)
            .HasColumnName("Description")
            .HasMaxLength(2000)
            .IsRequired();

        builder
            .Property(b => b.Price)
            .HasColumnName("Price")
            .HasPrecision(15,2)
            .IsRequired();

        builder
            .Property(b => b.Stock)
            .HasColumnName("Stock")
            .IsRequired();

        builder
            .HasMany(p => p.AttachmentProducts)
            .WithOne(a => a.Product)
            .HasForeignKey(a => a.ProductId);

        builder.ToTable("Product", "product");
    }
}