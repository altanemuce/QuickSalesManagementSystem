using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QSMS.Application.Repositories.Abstract.Category;
using QSMS.Application.Repositories.Abstract.CategoryProduct;
using QSMS.Application.Repositories.Abstract.Customer;
using QSMS.Application.Repositories.Abstract.Order;
using QSMS.Application.Repositories.Abstract.Product;
using QSMS.Application.Repositories.Abstract.ProductImage;
using QSMS.Application.Repositories.Abstract.ProductTag;
using QSMS.Application.Repositories.Abstract.Tag;
using QSMS.Domain.Entities.Identity;
using QSMS.Persistence.Contexts;
using QSMS.Persistence.Repositories.Category;
using QSMS.Persistence.Repositories.CategoryProduct;
using QSMS.Persistence.Repositories.Customer;
using QSMS.Persistence.Repositories.Order;
using QSMS.Persistence.Repositories.Product;
using QSMS.Persistence.Repositories.ProductImage;
using QSMS.Persistence.Repositories.ProductTag;
using QSMS.Persistence.Repositories.Tag;

namespace QSMS.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<QSMSDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("BaseConnection")));
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<QSMSDbContext>();
            services.AddScoped<ICategoryRepository, EfCategoryRepository>();
            services.AddScoped<ICustomerRepository, EfCustomerRepository>();
            services.AddScoped<ITagRepository, EfTagRepository>();
            services.AddScoped<IOrderRepository, EfOrderRepository>();
            services.AddScoped<IProductRepository, EfProductRepository>();
            services.AddScoped<IProductImageRepository, EfProductImageRepository>();
            services.AddScoped<ICategoryProductRepository, EfCategoryProductRepository>();
            services.AddScoped<IProductTagRepository, EfProductTagRepository>();
            return services;
        }
    }
}
