using Microsoft.AspNetCore.Mvc;
using OceanicAirlines.Engine;

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
        public string Get()
        {
            DataAggregator DataAggregator = new DataAggregator();
            DataAggregator.Aggregate();

            return "Hello from the DataAggregator";
        }
    }
}