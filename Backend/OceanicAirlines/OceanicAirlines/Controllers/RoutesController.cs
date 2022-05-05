using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OceanicAirlines.APIModels;
using System.Collections;

namespace OceanicAirlines.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly ILogger<RoutesController> _logger;

        public RoutesController(ILogger<RoutesController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "PostRoutes")]
        public IEnumerable<ApiRoute> Post([FromBody]APIRouteRequest req)
        {
            
            return Enumerable.Range(1, 5).Select(index => new ApiRoute(new Models.Route
            {
                Start = "Slavekysten",
                End = "Cairo",
                Price = (int)Random.Shared.NextInt64(),
                Time = (int)Random.Shared.NextInt64()
            }))
            .ToArray();
        }


    }

}
