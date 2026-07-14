using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants
{
    public interface IRestaurantsService
    {
        Task<IEnumerable<RestaurantDto>> GetAllRestaurnats();
        Task<RestaurantDto?> GetById(int id);
        Task<RestaurantDto> GetByName(string name);
    }
}