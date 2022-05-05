using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OceanicAirlines.APIModels;
using OceanicAirlines.Services;
using System.Collections;
using OceanicAirlines.Engine;

namespace OceanicAirlines.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly ILogger<RoutesController> _logger;

        public ListController(ILogger<RoutesController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetList")]  
        public string Get()
        {
            // init vars
            DataAggregator DataAggregator = new DataAggregator();
            ShortestPath ShortestPath = new ShortestPath();
            string StartCity = "A";  // decide the city you are starting from

            // find fastest path	
            (int[,] fastMatrix, List<string> fastCities) = DataAggregator.Aggregate(true, false);
            int fastSource = fastCities.IndexOf(StartCity); 
            ShortestPath.compute(fastMatrix, fastSource, fastCities);

            // find cheapest path
            (int[,] cheapMatrix, List<string> cheapCities) = DataAggregator.Aggregate(false, false);
            int cheapSource = cheapCities.IndexOf(StartCity);
            ShortestPath.compute(cheapMatrix, cheapSource, cheapCities);

            // find X alternative paths
            (int[,] altMatrix, List<string> altCities) = DataAggregator.Aggregate(true, true);
            int altSource = fastCities.IndexOf(StartCity);
            ShortestPath.compute(altMatrix, altSource, altCities);

            // send list back to requester
            return "abc";
        }

    }

}
