using OceanicAirlines.Models;

namespace OceanicAirlines.APIModels
{
    public class ApiRouteEIC
    {
        public ApiRouteEIC()
        { }
        public ApiRouteEIC(string Start, string End, int Time, double Price)
        {
            this.Source = Start;
            this.Destination = End;
            this.Price = (double)Price;
            this.Time = (int)Time;
        }

        public ApiRouteEIC(GetRoutePriceTableResult routeResult)
        {
            this.Source = routeResult.Source;
            this.Destination = routeResult.Destination;
            this.Price = (double)routeResult.Price;
            this.Time = (int)routeResult.Time;
        }

        public string Source { get; set; }
        public string Destination { get; set; }
        public int Time { get; set; }
        public double Price { get; set; }
    }
}
