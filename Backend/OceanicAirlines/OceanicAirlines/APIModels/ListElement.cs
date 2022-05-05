namespace OceanicAirlines.APIModels
{
    public class ListElement
    {
        public ListElement(string Start, string End, int Time, int Price, string path)
        {
            this.Source = Start;
            this.Destination = End;
            this.Price = Price;
            this.Time = Time;
            this.Path = path;

         }
        public string Source { get; set; }
        public string Destination { get; set; }
        public int Time { get; set; }
        public int Price { get; set; }
        public string Path { get; set; }
    }
}
