using Microsoft.AspNetCore.Mvc;
using OceanicAirlines.APIModels;
using OceanicAirlines.Services;

namespace OceanicAirlines.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BookingController
    {
        public BookingController()
        {
        }

        [HttpPost(Name = "Book")]
        public async Task<IActionResult> Post([FromBody] APIBookRequest req)
        {
            using (var context = new DbOaDk1Context())
            {
                var procedures = context.GetProcedures();
                await procedures.USP_INSERTBOOKINGSAsync(
                    req.Route,
                    req.Category,
                    req.Weight,
                    req.Length,
                    req.Width,
                    req.Height,
                    req.TotalPrice,
                    req.TotalTime,
                    req.CustomerFirstName,
                    req.CustomerLastName,
                    req.CustomerAddress,
                    req.CustomerZipCode,
                    req.CustomerCity,
                    req.CustomerCountry,
                    req.UserEmail,
                    default);
            }

            return new JsonResult(200);
        }
    }
}
