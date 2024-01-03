using Application.Abstractions;
using Application.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Concretes;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SignalRContext>(options => options.UseSqlServer(configuration.GetConnectionString("MsSql")));
        services.AddScoped<IAboutService, AboutManager>();
        services.AddScoped<IAboutRepository, AboutRepository>();
        services.AddScoped<IProductService, ProductManager>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<IBookingService, BookingManager>();
        services.AddScoped<IContactService, ContactManager>();
        services.AddScoped<IContactRepository, ContactRepository>();
        services.AddScoped<IDiscountService, DiscountManager>();
        services.AddScoped<IDiscountRepository, DiscountRepository>();
        services.AddScoped<IFeatureRepository, FeatureRepository>();
        services.AddScoped<IFeatureService, FeatureManager>();
        services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();
        services.AddScoped<ISocialMediaService, SocialMediaManager>();
        services.AddScoped<ITestimonialRepository, TestimonialRepository>();
        services.AddScoped<ITestimonialService, TestimonialManager>();
        services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
        services.AddScoped<IOrderDetailService, OrderDetailManager>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderService, OrderManager>();
        return services;
    }
}