namespace OceanicAirlines.APIModels
{
    public class APIBookRequest
    {
        public string Route { get; set; } = default!;
        public string Category { get; set; } = default!;
        public decimal Weight { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public string TotalPrice { get; set; } = default!;
        public decimal TotalTime { get; set; }
        public string CustomerFirstName { get; set; } = default!;
        public string CustomerLastName { get; set; } = default!;
        public string CustomerAddress { get; set; } = default!;
        public string CustomerZipCode { get; set; } = default!;
        public string CustomerCity { get; set; } = default!;
        public string CustomerCountry { get; set; } = default!;
        public string UserEmail { get; set; } = default!;

    }
}
