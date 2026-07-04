using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace Restaurants.API.Controllers;

public class TemperatureRequest
{
    public int Min { get; set; }
    public int Max { get; set; }
}

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherForecastService _weatherForecastService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, 
        IWeatherForecastService weatherForecastService)
    {
        _logger = logger;
        _weatherForecastService = weatherForecastService;
    }

    [HttpPost("generate")]
    public IActionResult Generate([FromQuery]int count, [FromBody] TemperatureRequest request)
    {
        if(count < 0 || request.Max < request.Min)
        {
            return BadRequest("Count has to be positive number, and max must ge greater that" +
                " the min value" );
        }

        var result = _weatherForecastService.Get();//(count, request.Min, request.Max);
        return Ok(result);

    }

    /*
    [HttpGet]
    [Route("{take}/example")]
    public IEnumerable<WeatherForecast> Get([FromQuery]int max, [FromRoute]int take)
    {
        var result = _weatherForecastService.Get();
        Response.StatusCode = 400;
        return result;
    }

    [HttpGet]
    [Route("currentDay")]
    public WeatherForecast GetCurrentDay()
    {
        var result = _weatherForecastService.Get().First();
        return result;
    }

    [HttpPost]
    public string Hello([FromBody] string name)
    {
        return $"Hello {name}";
    }

    */

}
