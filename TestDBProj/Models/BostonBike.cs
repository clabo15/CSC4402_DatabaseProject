using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text;
using FileHelpers;

namespace TestDBProj.Models
{
    [DelimitedRecord(",")]
    [IgnoreFirst(1)]
    public class BostonBike : AuditableEntity
    {       
        public int StationId { get; set; }
        public string Name { get; set; }   
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int TripsEnded { get; set; }
        public int TripsStarted { get; set; }
        public int TripsTotal { get; set; }
        public double FpctStarted { get; set; }
        public double FpctEnded { get; set; }
        public double FpctTotal { get; set; }

    }
}
