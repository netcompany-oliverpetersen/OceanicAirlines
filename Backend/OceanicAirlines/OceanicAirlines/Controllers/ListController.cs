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
            // get data matrix
            DataAggregator DataAggregator = new DataAggregator();
            (int[,] matrix, List<string> cities) = DataAggregator.Aggregate();

            // find shortest path	
			ShortestPath ShortestPath = new ShortestPath();
            int source = cities.IndexOf("A");  // decide the city you are starting from
            ShortestPath.compute(matrix, source, cities);

            // find cheapest path
            // find X alternative paths
            // send them back

            return "abc";
        }

    }

}
