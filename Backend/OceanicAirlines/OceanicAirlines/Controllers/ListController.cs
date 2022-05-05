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
        public async Task<IEnumerable<ListElement>> Post([FromBody] ListRequest req)
        {
            // init vars
            DataAggregator DataAggregator = new DataAggregator();
            ShortestPath ShortestPath = new ShortestPath();

            string StartCity = req.Source;  // decide the city you are starting from
            string EndCity = req.Destination;

            // find fastest path	
            (int[,] fastMatrix, List<string> fastCities) = DataAggregator.Aggregate(true, false);
            int fastSource = fastCities.IndexOf(StartCity);
            int fastSink = fastCities.IndexOf(EndCity);
            ListElement shortestElem = ShortestPath.Compute(fastMatrix, fastCities, fastSource, fastSink);

            //// find cheapest path
            //(int[,] cheapMatrix, List<string> cheapCities) = DataAggregator.Aggregate(false, false);
            //int cheapSource = cheapCities.IndexOf(StartCity);
            //ShortestPath.compute(cheapMatrix, cheapSource, cheapCities);

            //// find X alternative paths
            //(int[,] altMatrix, List<string> altCities) = DataAggregator.Aggregate(true, true);
            //int altSource = fastCities.IndexOf(StartCity);
            //ShortestPath.compute(altMatrix, altSource, altCities);

            // send list back to requester
            List<ListElement> returnList = new List<ListElement>();
            //returnList.Add(new ListElement(req.Source, "Aarhus", 4, 5, "Ry,Skanderborg,Aarhus"));
            returnList.Add(shortestElem);
            return returnList;
        }

    }

}
