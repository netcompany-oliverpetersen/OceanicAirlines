using Microsoft.AspNetCore.Mvc;
using OceanicAirlines.Services;
using OceanicAirlines.Models;
using System.Collections;

namespace OceanicAirlines.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<City> Get()
        {

            List<City> cities = new List<City>();
            using (var context = new DbOaDk1Context())
            {
                 cities = context.City.ToList();
                
            }

            return cities;
        }
    }
}