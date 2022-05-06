using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OceanicAirlines.APIModels;
using OceanicAirlines.Services;
using OceanicAirlines.Models;
using System.Collections;

namespace OceanicAirlines.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackingController : ControllerBase
    {

        [HttpGet(Name = "GetTracking")]
        public async Task<City> Get(int id)
        {
            var city = new City();
            List<Bookingline> bookings = new List<Bookingline>();
            Booking booking = new Booking();
            using (var context = new DbOaDk1Context())
            {
                bookings = context.Bookingline.Where(p => p.ParcelId == id).OrderBy(p => p.SegmentId).ToList();
                int bookingId = bookings.First().Id;
                booking = context.Booking.Where(p => p.Id == bookingId).FirstOrDefault();
            }
            DateTime diff = DateTime.Now;
            int hourdiff = diff.Subtract(booking.Timestamp).Hours;

            foreach (Bookingline line in bookings)
            {
                if(line.DistanceInHours < hourdiff)
                {
                    hourdiff = hourdiff - (int)line.DistanceInHours;
                }
                else
                {
                    city = line.StartPos;
                    break;
                }
            }
            return city;

        }
    }
}
