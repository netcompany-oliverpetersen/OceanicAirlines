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
        public RoutesController()
        {
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

    }

}
