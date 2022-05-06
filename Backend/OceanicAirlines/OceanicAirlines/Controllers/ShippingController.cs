using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OceanicAirlines.Models;
using OceanicAirlines.APIModels;
using OceanicAirlines.Services;
using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace OceanicAirlines.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController : ControllerBase
    {
        [HttpGet(Name = "GetShipping")]
        public async Task<IEnumerable<ApiBookingHistory>> Get()
        {
            List<ApiBookingHistory> bookingHist = new List<ApiBookingHistory>();
            List<Booking> booking = new List<Booking>();
            using (var context = new DbOaDk1Context())
            {
                booking = context.Booking.ToList();
            }
            foreach ( var b in booking)
            {
                List<Bookingline> bookingLine = new List<Bookingline>();
                using (var context = new DbOaDk1Context())
                {
                    bookingLine = context.Bookingline.Where(p => p.Id == b.Id).ToList();
                }
                bookingHist.Add(new ApiBookingHistory { booking = b, bookingLines = bookingLine });
            }
            return bookingHist;
        }
    }
}
