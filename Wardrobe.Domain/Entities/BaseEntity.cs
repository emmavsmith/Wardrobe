using System;

namespace Wardrobe.Domain.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            DateCreated = DateTime.UtcNow;
            LastUpdated = DateTime.UtcNow;
        }

        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}