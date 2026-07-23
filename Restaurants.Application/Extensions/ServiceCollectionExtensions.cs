using FluentValidation;
using Restaurants.Application.Restaurants;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Domain.Repositories;
using MediatR;

namespace Restaurants.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;

        services.AddLogging();

        //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));
        
        //services.AddScoped<IRestaanteurantsService, RestaurantsService>();
        //services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);
        
        services.AddAutoMapper(applicationAssembly);

        services.AddValidatorsFromAssemblies(new[] { applicationAssembly })
            .AddFluentValidationAutoValidation();
    }
}