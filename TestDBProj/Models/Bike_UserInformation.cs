using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDBProj.Models
{
    public class Bike_UserInformation : AuditableEntity
    {
        public Guid BikeId { get; set; }
        public Bike Bike { get; set; }
        public Guid UserInformationId { get; set; }
        public UserInformation UserInformation { get; set; }
    }
}
