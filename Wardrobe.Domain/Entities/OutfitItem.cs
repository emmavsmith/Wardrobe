using System.Collections.Generic;

namespace Wardrobe.Domain.Entities
{
    // Association table

    public class OutfitItem : BaseEntity
    {
        public OutfitItem()
        {
            // Parameterless constructor for EF
        }

        public long OutfitId { get; set; }
        public Outfit Outfit { get; set; }
        public Item Item { get; set; }
        public long ItemId { get; set; }

        public virtual ICollection<Outfit> Outfits { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}