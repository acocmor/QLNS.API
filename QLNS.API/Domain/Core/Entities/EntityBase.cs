using System;
using System.ComponentModel.DataAnnotations;

namespace QLNS.Domain.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public Guid Id { get; set; }
    }
}
