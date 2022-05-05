namespace OceanicAirlines.APIModels
{
    public class APIRouteRequest
    {
        public APIRouteRequest(string Category, int Height, int Length, int Width, int Weight)
        {
            this.Category = Category;
            this.Height = Height;
            this.Length = Length;
            this.Width = Width;
            this.Weight = Weight;
        }

        public string Category { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public double Weight { get; set; }
    }
}
