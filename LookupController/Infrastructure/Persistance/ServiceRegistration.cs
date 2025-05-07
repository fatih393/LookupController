using Lookupcontroller.Application.Repostories;
using Lookupcontroller.Application.Services.BusinessRules;
using Lookupcontroller.Application.Services.EntityServices;
using Lookupcontroller.Persistance.Context;
using Lookupcontroller.Persistance.Repositories;
using Lookupcontroller.Persistance.Services.BusinessRules;
using Lookupcontroller.Persistance.Services.EntityServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Lookupcontroller.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LookupcontrollerContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductBusinessRules, ProductBusinessRules>();
        }
        }
}
