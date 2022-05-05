namespace OceanicAirlines.APIModels
{
    public class ApiRoute
    {
        public ApiRoute(Models.Route model)
        {
            this.Source = model.Start;
            this.Destination = model.End;
            this.Price = model.Price;
            this.Time = model.Time;
        }
        public string Source { get; set; }
        public string Destination { get; set; }
        public int Time { get; set; }
        public int Price { get; set; }
    }
}
