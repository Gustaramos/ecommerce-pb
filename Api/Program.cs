using ECommerceApp.Data;
using ECommerceApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (connectionString is not null)
{
    builder.Services.AddDbContext<ApplicationDbContext>(options => 
    {
        options.UseNpgsql(connectionString);
    });
}
else
{
    throw new Exception("Connection String not found");
}

builder.Services.AddControllers();

//Dependency injection de Services
builder.Services.AddScoped<IProductService, ProductService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();