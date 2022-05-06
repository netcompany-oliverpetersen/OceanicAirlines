using Microsoft.AspNetCore.Mvc;
using OceanicAirlines.Services;
using OceanicAirlines.Models;
using System.Collections;
using OceanicAirlines.APIModels;

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
            string Start = "A";
            string End = "B";
            int Time = 2;
            int Price = 3;
            string path = "AB";

            ListElement elemA = new ListElement(Start, End, Time, Price, path);
            ListElement elemB = new ListElement(Start, End, Time, Price, path);
            Console.WriteLine(elemA == elemB);


            List<City> cities = new List<City>();
            using (var context = new DbOaDk1Context())
            {
                 cities = context.City.ToList();
                
            }

            return cities;
        }
    }
}