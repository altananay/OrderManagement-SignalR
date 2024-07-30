using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System.Configuration;

namespace WebUI;

public static class WebUIServiceRegistration
{
    public static IServiceCollection AddWebUIServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient();
        services.AddIdentity<User, Role>().AddEntityFrameworkStores<SignalRContext>();
        services.AddDbContext<SignalRContext>(options => options.UseSqlServer(configuration.GetConnectionString("MsSql")));
        return services;
    }
}