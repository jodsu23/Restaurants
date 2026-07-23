
/*using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;
using Restaurants.Domain.Repositories;
using System.Xml.Linq;*/

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantByName 
{ 

    internal class GetRestaurantByNameQueryHandler(
        ILogger<GetRestaurantByNameQueryHandler> logger,
        IRestaurantsRepository restaurantsRepository,
        IMapper mapper
    ) : IRequestHandler<GetRestaurantByNameQuery, RestaurantDto>
    {
        public async Task<RestaurantDto> Handle(GetRestaurantByNameQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Getting restaurant {request.Name}");

            var restaurant = await restaurantsRepository.GetByNameAsync(request.Name);
            var restaurantDto = mapper.Map<RestaurantDto>(restaurant);

            return restaurantDto!;
        }
    }

}