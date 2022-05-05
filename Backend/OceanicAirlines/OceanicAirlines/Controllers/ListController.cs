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

        [HttpPost(Name = "PostList")]  
        public string Post([FromBody]string req)
        {
            // get data matrix
            DataAggregator DataAggregator = new DataAggregator();
            int[,] matrix = DataAggregator.Aggregate();

            // find shortest path
            			// decide source
			int source = cities.IndexOf("A");

		
			ShortestPath ShortestPath = new ShortestPath();
            ShortestPath.compute(matrix, source, cities);
            // find cheapest path
            // find X alternative paths
            // send them back

            return "abc";
        }

    }

}
