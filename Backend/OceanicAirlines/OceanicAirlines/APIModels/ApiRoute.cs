namespace OceanicAirlines.APIModels
{
    public class ApiRoute
    {
        public ApiRoute()
        { }
            public ApiRoute(Models.Route model)
        {
            this.Source = model.StartPos.CityName;
            this.Destination = model.EndPos.CityName;
            this.Price = 20;
            this.Time = (int)model.DistanceInHours;
        }
        public ApiRoute(string Start, string End, int Time, int Price)
        {
            this.Source = Start;
            this.Destination = End;
            this.Price = Price;
            this.Time = Time;
        }
        public string Source { get; set; }
        public string Destination { get; set; }
        public int Time { get; set; }
        public int Price { get; set; }
    }
}
