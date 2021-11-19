using FileHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TestDBProj.Interfaces;

namespace TestDBProj.Models
{
    public class AuditableEntity : IAuditableEntity
    {
        [Key]
        [FieldHidden]
        public Guid Id { get; set; }
        [FieldHidden]
        public DateTime UpdatedDate { get; set; }
        [FieldHidden]
        public DateTime CreatedDate { get; set; }
        public AuditableEntity()
        {
            Id = Guid.NewGuid();
            UpdatedDate = DateTime.Now;
            CreatedDate = DateTime.Now;
        }
    }
}
