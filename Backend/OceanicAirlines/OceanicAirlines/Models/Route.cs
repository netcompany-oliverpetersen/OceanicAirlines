﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace OceanicAirlines.Models
{
    public partial class Route
    {
        public int Id { get; set; }
        public int? StartPosId { get; set; }
        public int? EndPosId { get; set; }
        public decimal? DistanceInHours { get; set; }
        public bool? Active { get; set; }

        public virtual City EndPos { get; set; }
        public virtual City StartPos { get; set; }
    }
}