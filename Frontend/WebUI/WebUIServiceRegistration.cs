namespace WebUI;

public static class WebUIServiceRegistration
{
    public static IServiceCollection AddWebUIServices(this IServiceCollection services)
    {
        services.AddHttpClient();
        return services;
    }
}