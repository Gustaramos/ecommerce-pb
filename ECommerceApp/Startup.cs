using ECommerceApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options => 
        options.UseSqlServer(IConfiguration.GetConnectionString("DefaultConnection")));

        services.AddControllersWithViews();
    }

   
}
