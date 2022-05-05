namespace OceanicAirlines.APIModels
{
    public class ListRequest 
    { 
    public string? Source { get; set; }
    public string? Destination { get; set; }
    public double Height { get; set; }
    public double Width { get; set; }
    public double Length { get; set; }
    public double Weight { get; set; }
    public string? Category { get; set; }
    }

}
