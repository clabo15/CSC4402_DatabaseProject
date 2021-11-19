using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TestDBProj.Models
{
    public class Bike_ModelType : AuditableEntity
    {
        public Guid BikeId {  get; set; }
        public Bike Bike { get; set; }
        public Guid ModelTypeId { get; set; }
        public ModelType ModelType { get; set; }
    }
}
