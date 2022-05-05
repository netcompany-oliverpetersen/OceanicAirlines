using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OceanicAirlines.APIModels;
using OceanicAirlines.Services;
using System.Collections;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IEnumerable<ApiRoute>> Post([FromBody]APIRouteRequest req)
        {
            List<ApiRoute> returnRoutes = new List<ApiRoute>();
            List<Models.Route> routes = new List<Models.Route>();
            using (var context = new DbOaDk1Context())
            {
                routes = context.Route.Include(route => route.EndPos).ToList();
            }
               foreach (var route in routes)
            {
                returnRoutes.Add(new ApiRoute(route));
            }
               return returnRoutes; 
        }

        [HttpGet(Name ="GetRoute")]
        public async Task<IEnumerable<ApiRoute>> Get()
        {
            TelstarService ts = new TelstarService();
            return await ts.GetApiRoutes(new APIRouteRequest { Category = "test", Height = 0, Length = 0, Weight = 0, Width = 0 });

        }

    }

}
