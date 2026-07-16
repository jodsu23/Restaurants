using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repositories;
using System.Reflection.Metadata.Ecma335;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/restaurants")]
public class RestaurantsController(IRestaurantsService restaurantsService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var restaurants = await restaurantsService.GetAllRestaurnats();
        return Ok(restaurants);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute]int id)
    {
        var restaurant = await restaurantsService.GetById(id);
        if (restaurant is null)
            return NotFound();

        return Ok(restaurant);
    }

    [HttpGet("by-name/{name}")]
    public async Task<IActionResult> GetByName([FromRoute]string name)
    {
        var restaurant = await restaurantsService.GetByName(name);

        return Ok(restaurant);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRestaurant([FromBody]CreateRestaurantDto createRestaurantDto)
    {
        int id = await restaurantsService.Create(createRestaurantDto);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

}