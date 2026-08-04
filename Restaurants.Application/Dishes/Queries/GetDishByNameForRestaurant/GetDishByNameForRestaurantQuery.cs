
using MediatR;
using Restaurants.Application.Dishes.Dtos;

namespace Restaurants.Application.Dishes.Queries.GetDishByNameForRestaurant;

public class GetDishByNameForRestaurantQuery(string dishName) : IRequest<DishDto>
{
    public string DishName { get; } = dishName;
}