using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileHelpers;

namespace TestDBProj.Models
{
    [DelimitedRecord(",")]
    [IgnoreFirst(1)]
    public class Bike : AuditableEntity
    {
        public int SerialNumber { get; set; }
    }
}
