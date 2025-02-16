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
            return await _context
                .Products
                .ToListAsync();
        }
        
        public async Task AddAsync(ProductModel productModel, CancellationToken cancellationToken)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
            
            try
            {
                var uploadFiles = await UploadFilesAsync(productModel.Files, cancellationToken);

                foreach (var upload in uploadFiles)
                {
                    var teste = await _context.Attachments.ToListAsync(cancellationToken);
                }
                
                var product = await AddProductAsync(new ProductDto
                {
                    Description = productModel.Description,
                    Name = productModel.Name,
                    Price = productModel.Price,
                    Stock = productModel.Stock
                }, cancellationToken);
            
                await SaveAttachmentProductsAsync(
                    product.Id,
                    uploadFiles
                        .Select(a => a.Id),
                    cancellationToken);

                await transaction.CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
            }
        }

        public async Task UpdateAsync(Product productToUpdate, CancellationToken cancellationToken)
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
                
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        private async Task<IEnumerable<Attachment>> UploadFilesAsync(IEnumerable<IFormFile> files, CancellationToken cancellationToken)
        {
            //TODO: Quando tiver um servidor pra guardar os arquivos
            //mudar essa parte, para realizar o upload no servidor tbm
            
            //Entender pq esse tracho nao deu certo
             /*var filesToUpload = files
                 .Select(a => 
                     new Attachment(
                         Guid.NewGuid(),
                         a.ContentType,
                         a.FileName,
                         a.Length));

             var teste = filesToUpload.Select(a => a.Id);
             
             Console.WriteLine($"Gerado antes do entity: {string.Join(',', teste)}");*/
             var teste = new List<Attachment>();
             
             foreach (var file in files)
             {
                 
                 var attachment = new Attachment(
                     Guid.NewGuid(),
                     file.ContentType,
                     file.FileName,
                     file.Length);
                 
                 Console.WriteLine($"Gerado ao antes do entity: {string.Join(',', attachment.Id)}");
                 
                 teste.Add(attachment);
                 
                 await _context
                     .Attachments
                     .AddAsync(attachment, cancellationToken);
                 
                 Console.WriteLine($"Gerado ao depois do entity: {string.Join(',', attachment.Id)}");
             }
             
             var testeAdd = teste.Select(a => a.Id);
             
             Console.WriteLine($"Gerado ao add do entity: {string.Join(',', testeAdd)}");

             await _context.SaveChangesAsync(cancellationToken);
             
             var testeDepois = teste.Select(a => a.Id);
             
             Console.WriteLine($"Gerado depois do entity: {string.Join(',', testeDepois)}");

             return teste;
        }

        private async Task SaveAttachmentProductsAsync(
            Guid productId,
            IEnumerable<Guid> attachmentIds,
            CancellationToken cancellationToken)
        {
            var attachmentProducts = new List<AttachmentProduct>();

            foreach (var attachmentId in attachmentIds)
            {
                var attachmentProduct = new AttachmentProduct(productId, attachmentId);
                
                attachmentProducts.Add(attachmentProduct);
                
                _context
                    .AttachmentProducts
                    .Add(attachmentProduct);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }
        
        private async Task<Product> AddProductAsync(ProductDto productDto, CancellationToken cancellationToken)
        {
            var product = new Product(
                productDto.Name,
                productDto.Description,
                productDto.Price,
                productDto.Stock);

            
            _context.Products.Add(product);

            await _context.SaveChangesAsync(cancellationToken);

            return product;
        }
    }
}