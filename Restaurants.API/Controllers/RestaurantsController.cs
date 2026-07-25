using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;
using Restaurants.Application.Restaurants.Queries.GetRestaurantByName;
using Restaurants.Domain.Repositories;
using System.Reflection.Metadata.Ecma335;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/restaurants")]
//public class RestaurantsController(IRestaurantsService restaurantsService) : ControllerBase
public class RestaurantsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        //var restaurants = await restaurantsService.GetAllRestaurnats();
        var restaurants = await mediator.Send(new GetAllRestaurantsQuery());
        return Ok(restaurants);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute]int id)
    {
        //var restaurant = await restaurantsService.GetById(id);
        var restaurant = await mediator.Send(new GetRestaurantByIdQuery(id));

        if (restaurant is null)
            return NotFound();

        return Ok(restaurant);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
    {
        var idDeleted = await mediator.Send(new DeleteRestaurantCommand(id));

        if (idDeleted)
            return NoContent();

        return NotFound();
    }

    [HttpGet("by-name/{name}")]
    public async Task<IActionResult> GetByName([FromRoute]string name)
    {
        //var restaurant = await restaurantsService.GetByName(name);
        var restaurant = await mediator.Send(new GetRestaurantByNameQuery(name));

        return Ok(restaurant);
    }

    [HttpPost]
    //public async Task<IActionResult> CreateRestaurant([FromBody]CreateRestaurantDto createRestaurantDto)
    public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand command)
    {
        //int id = await restaurantsService.Create(createRestaurantDto);
        int id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

}