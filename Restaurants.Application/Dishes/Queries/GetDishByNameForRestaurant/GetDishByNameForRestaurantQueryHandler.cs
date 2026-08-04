
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetDishByNameForRestaurant;

public class GetDishByNameForRestaurantQueryHandler(ILogger<GetDishByNameForRestaurantQueryHandler> logger,
    IRestaurantsRepository restaurantsRepository,
    IDishesRepository dishesRepository,
    IMapper mapper
    ) : IRequestHandler<GetDishByNameForRestaurantQuery, DishDto>
{
    public async Task<DishDto> Handle(GetDishByNameForRestaurantQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Obtener el nombre del plato dish: {DishName}", request.DishName);

        //var dish = await restaurantsRepository.GetByNameAsync(request.DishName);
        var dish = await dishesRepository.GetNameAsync(request.DishName); //GetByNameAsync(request.DishName);

        if (dish == null)
            throw new NotFoundException(nameof(Dish), request.DishName.ToString());

        //var dishName = dish.Dishes.FirstOrDefault(d => d.Name == request.DishName);

        var result = mapper.Map<DishDto>(dish);

        return result;
    }
}
