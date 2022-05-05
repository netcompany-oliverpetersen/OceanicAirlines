using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OceanicAirlines.APIModels;
using OceanicAirlines.Services;
using OceanicAirlines.Models;
using System.Collections;

namespace OceanicAirlines.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController
    {
        [HttpGet(Name = "GetCities")]
        public async Task<IEnumerable<City>> Get()
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
