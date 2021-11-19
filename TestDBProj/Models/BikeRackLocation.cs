using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileHelpers;

namespace TestDBProj.Models
{
    [DelimitedRecord(",")]
    [IgnoreFirst(1)]
    public class BikeRackLocation : AuditableEntity
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }   
        public int TripsTotal { get; set; }
    }
}
