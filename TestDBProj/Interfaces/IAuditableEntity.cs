using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestDBProj.Interfaces
{
    public interface IAuditableEntity
    {
        Guid Id { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }
    }
}
