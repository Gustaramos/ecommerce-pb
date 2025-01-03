using Microsoft.EntityFrameworkCore;
using ECommerceApp.Data;

var builder = WebApplication.CreateBuilder(args);

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

// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.MapControllers();

app.Run();



