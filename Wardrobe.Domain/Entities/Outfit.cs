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
            OutfitItems = new List<OutfitItem>();
        }

        public string Name { get; set; }
        public long? ImageId { get; set; }
        public OutfitImage Image { get; set; }
        public User User { get; set; }
        public long UserId { get; set; }

        public virtual ICollection<OutfitItem> OutfitItems { get; set; }
    }
}