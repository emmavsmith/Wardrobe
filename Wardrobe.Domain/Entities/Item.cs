using System.Collections.Generic;
using Wardrobe.Domain.Enums;

namespace Wardrobe.Domain.Entities
{
    public class Item : BaseEntity
    {
        public Item()
        {
            // Parameterless constructor for EF
        }

        public Item(string name, long userId, ItemCategory category)
        {
            Name = name;
            UserId = userId;
            Category = category;
            OutfitItems = new List<OutfitItem>();
        }

        public string Name { get; set; }
        public long? ImageId { get; set; }
        public ItemImage Image { get; set; }
        public ItemCategory Category { get; set; }
        public User User { get; set; }
        public long UserId { get; set; }

        public virtual ICollection<OutfitItem> OutfitItems { get; set; }
    }
}