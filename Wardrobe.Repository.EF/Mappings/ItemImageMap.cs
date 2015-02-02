using Wardrobe.Domain.Entities;

namespace Wardrobe.Repository.EF.Mappings
{
    internal class ItemImageMap : BaseEntityMap<ItemImage>
    {
        public ItemImageMap() : base("ItemImage")
        {
            Property(x => x.SourceBytes).IsRequired();
            Property(x => x.ContentType).IsRequired();
        }
    }
}