using Core.Entities.Identity;
using System;

namespace Core.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public User CreatedBy { get; set; }
        public User UpdatedBy { get; set; }
    }
}
