using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants;

internal class RestaurantsService(IRestaurantsRepository restaurantsRepository,
    ILogger<RestaurantsService> logger) : IRestaurantsService
{
    public async Task<IEnumerable<RestaurantDto>> GetAllRestaurnats()
    {
        logger.LogInformation("Getting all restaurants");
        var restaurants = await restaurantsRepository.GetAllAsync();

        //var restaurantDto = restaurants.Select(r => new RestaurantDto()
        var restaurantDto = restaurants.Select(RestaurantDto.FromEntity);
        /*{    
            Category = r.Category,
            Description = r.Description,
            Id = r.Id,
            HasDelivery = r.HasDelivery,
            Name = r.Name,
            City = r.Address?.City,
            Street = r.Address?.Street,
            PostalCode = r.Address?.PostalCode, 
        });*/

        return restaurantDto!;
    }

    public async Task<RestaurantDto?> GetById(int id)
    {
        logger.LogInformation($"Getting restaurant {id}");
        var restaurant = await restaurantsRepository.GetByIdAsync(id);

        var restaurantDto = RestaurantDto.FromEntity(restaurant);

        return restaurantDto;
    }

    public async Task<RestaurantDto> GetByName(string name)
    {
        logger.LogInformation($"Getting restaurant {name}");
        var restaurant = await restaurantsRepository.GetByNameAsync(name);

        var restaurantDto = RestaurantDto.FromEntity(restaurant);

        return restaurantDto!;
    }
}