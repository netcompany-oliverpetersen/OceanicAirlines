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
            List<ListElement> returnList = new List<ListElement>();

            string StartCity = req.Source;  // decide the city you are starting from
            string EndCity = req.Destination;
            APIRouteRequest request = new APIRouteRequest { Category = req.Category, Height = req.Height, Length = req.Length, Weight = req.Weight, Width = req.Width};

            // find fastest path	
            (int[,] TimeMatrix, int[,] PriceMatrix, List<string> fastCities) = DataAggregator.Aggregate(false, request);
            int fastSource = fastCities.IndexOf(StartCity);
            int fastSink = fastCities.IndexOf(EndCity);
            ListElement FastestElem = ShortestPath.Compute(TimeMatrix, PriceMatrix, fastCities, fastSource, fastSink, false);
            // find cheapest path
            ListElement CheapestElem = ShortestPath.Compute(PriceMatrix, TimeMatrix, fastCities, fastSource, fastSink, true);
            returnList.Add(FastestElem);
            returnList.Add(CheapestElem);


            // find X alternative paths
            for (int i = 0; i < 5; i++)
            {
                (int[,] altTimeMatrix, int[,] altPriceMatrix, List<string> altCities) = DataAggregator.Aggregate(true, request);
                int altSource = altCities.IndexOf(StartCity);
                int altSink = altCities.IndexOf(EndCity);
                try
                {
                    ListElement altElem = ShortestPath.Compute(altTimeMatrix, altPriceMatrix, altCities, altSource, altSink, false);
                    returnList.Add(altElem);
                } 
                catch (IndexOutOfRangeException) { Console.WriteLine("Failed alternative route."); }
            }

            // remove duplicates
            returnList.GroupBy(elem => new { elem.Time, elem.Price, elem.Path }).Select(group => group.First());
            return returnList;
        }

    }

}
