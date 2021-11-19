using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileHelpers;

namespace TestDBProj.Models
{
    [DelimitedRecord(",")]
    [IgnoreFirst(1)]
    public class ModelType : AuditableEntity
    {
        public string Name { get; set; }
    }
}
