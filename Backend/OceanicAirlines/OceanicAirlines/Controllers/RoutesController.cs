using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OceanicAirlines.APIModels;
using OceanicAirlines.Services;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using OceanicAirlines.Models;

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
            List<GetRoutePriceTableResult> results = new List<GetRoutePriceTableResult>();

            using (var context = new DbOaDk1Context())
            {
                var procedures = context.GetProcedures();
                results = await procedures.GetRoutePriceTableAsync(req.Height, req.Width, req.Length, req.Weight, req.Category);
            }

            foreach(var result in results)
            {
                returnRoutes.Add(new ApiRoute(result));
            }

               return returnRoutes; 
        }
    }

}
