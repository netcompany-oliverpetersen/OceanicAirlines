// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OceanicAirlines.Models
{
    public partial class GetRoutePriceTableResult
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public decimal? Time { get; set; }
        public decimal? Price { get; set; }
    }
}
