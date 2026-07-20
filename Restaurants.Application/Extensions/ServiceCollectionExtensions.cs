using FluentValidation;
using Restaurants.Application.Restaurants;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;

        services.AddScoped<IRestaurantsService, RestaurantsService>();
        //services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);
        
        services.AddAutoMapper(applicationAssembly);

        services.AddValidatorsFromAssemblies(new[] { applicationAssembly })
            .AddFluentValidationAutoValidation();
    }
}