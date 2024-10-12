using Application.Facade;
using Application.Validations.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<EntityServices>();
        services.AddValidatorsFromAssemblyContaining<CreateBookingValidator>();
        return services;
    }
}