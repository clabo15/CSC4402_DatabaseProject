using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDBProj.Models
{
    public class Bike_BikeRackLocation : AuditableEntity
    {
        public Guid BikeId { get; set; }
        public Bike Bike { get; set; }
        public Guid BikeRackLocationId { get; set; }
        public BikeRackLocation BikeRackLocation { get; set; }
    }
}
