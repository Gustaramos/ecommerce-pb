using Api.Dto;
using ECommerceApp.Data;
using ECommerceApp.Entities;
using ECommerceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Services
{
    //TODO: Refatorar para utilizar o padrao repository
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }
        
        public async Task AddAsync(ProductModel productModel)
        {
            var uploadFiles = await UploadFilesAsync(productModel.Files);

            var product = await AddProductAsync(new ProductDto
            {
                Description = productModel.Description,
                Name = productModel.Name,
                Price = productModel.Price,
                Stock = productModel.Stock
            });
            
            await SaveAttachmentProductsAsync(
                product.Id,
                uploadFiles
                    .Select(a => a.Id));
        }

        public async Task UpdateAsync(Product productToUpdate)
        {
            var product = await _context
                .Products
                .FirstOrDefaultAsync(p => p.Id == productToUpdate.Id);

            if (product is not null)
            {
                product.Description = productToUpdate.Description;
                product.Name = productToUpdate.Name;
                product.Stock = productToUpdate.Stock;
                product.Price = productToUpdate.Price;
                
                _context.Update(product);
            }
            
            await _context.SaveChangesAsync();
        }

        private async Task<IEnumerable<Attachment>> UploadFilesAsync(IEnumerable<IFormFile> files)
        {
            //TODO: Quando tiver um servidor pra guardar os arquivos
            //mudar essa parte, para realizar o upload no servidor tbm

             var filesToUpload = files
                 .Select(a => 
                     new Attachment(
                         Guid.NewGuid(),
                         a.ContentType,
                         a.FileName,
                         a.Length));

             await _context
                 .Attachments
                 .AddRangeAsync(filesToUpload);

             await _context.SaveChangesAsync();

             return filesToUpload;
        }

        private async Task SaveAttachmentProductsAsync(
            Guid productId,
            IEnumerable<Guid> attachmentIds)
        {
            var attachmentProducts = attachmentIds
                .Select(a => new AttachmentProduct(productId, a));

            await _context
                .AttachmentProducts
                .AddRangeAsync(attachmentProducts);

            await _context.SaveChangesAsync();
        }
        
        private async Task<Product> AddProductAsync(ProductDto productDto)
        {
            var product = new Product(
                productDto.Name,
                productDto.Description,
                productDto.Price,
                productDto.Stock);

            
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }
    }
}