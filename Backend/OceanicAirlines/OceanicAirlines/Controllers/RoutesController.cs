using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OceanicAirlines.APIModels;
using OceanicAirlines.Services;
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

        public RoutesController()
        {
        }

        [HttpPost(Name = "PostRoutes")]
        public IEnumerable<ApiRoute> Post([FromBody]APIRouteRequest req)
        {

            return Enumerable.Range(1, 5).Select(index => new ApiRoute(new Models.Route
            {
                StartPosId = 2,
                EndPosId = 1,
                DistanceInHours = (int)Random.Shared.NextInt64()
            }))
            .ToArray();
        }

        [HttpGet(Name ="GetRoute")]
        public async Task<IEnumerable<ApiRoute>> Get()
        {
            TelstarService ts = new TelstarService();
            return await ts.GetApiRoutes(new APIRouteRequest { Category = "test", Height = 0, Length = 0, Weight = 0, Width = 0 });

        }

    }

}
