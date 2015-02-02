using System.Collections.Generic;

namespace Wardrobe.Domain.Entities
{
    public class Outfit : BaseEntity
    {
        public Outfit()
        {
            // Parameterless constructor for EF
        }

        public Outfit(string name, long userId)
        {
            Name = name;
            UserId = userId;
            Items = new List<Item>();
        }

        public string Name { get; set; }
        public OutfitImage Image { get; set; }

        public User User { get; set; }
        public long UserId { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}