using OceanicAirlines.Models;

namespace OceanicAirlines.APIModels
{
    public class ApiBookingHistory
    {
        public Booking booking {get; set; }

        public List<Bookingline> bookingLines { get; set; }
    }
}
