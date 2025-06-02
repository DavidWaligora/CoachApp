using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoachApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];
        private readonly List<WeatherForecast> weatherForecasts =
        [
            new()
            {
                WeatherID = 1,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            },
            new()
            {
                WeatherID = 1,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }
        ];

        [HttpGet(Name = "GetWeatherForecast")]
        [AllowAnonymous]
        public IEnumerable<WeatherForecast> Get()
        {
            return [.. Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })];
        }

        [HttpGet("{id}", Name = "GetWeatherById")]
        public WeatherForecast? GetById(int id)
        {
            return weatherForecasts.Where(x => x.WeatherID == id).FirstOrDefault();
        }
    }
}
