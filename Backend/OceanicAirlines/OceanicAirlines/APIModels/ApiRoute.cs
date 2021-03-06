using OceanicAirlines.Models;

namespace OceanicAirlines.APIModels
{
    public class ApiRoute
    {
        public ApiRoute()
        { }
        public ApiRoute(string Start, string End, int Time, int Price)
        {
            this.Source = Start;
            this.Destination = End;
            this.Price = (int)Price;
            this.Time = (int)Time;
        }

        public ApiRoute(GetRoutePriceTableResult routeResult)
        {
            this.Source = routeResult.Source;
            this.Destination = routeResult.Destination;
            this.Price = (int)routeResult.Price;
            this.Time = (int)routeResult.Time;
        }

        public string Source { get; set; }
        public string Destination { get; set; }
        public int Time { get; set; }
        public int Price { get; set; }
    }
}
