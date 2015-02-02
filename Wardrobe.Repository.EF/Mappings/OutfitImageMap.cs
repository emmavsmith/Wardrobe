using Wardrobe.Domain.Entities;

namespace Wardrobe.Repository.EF.Mappings
{
    internal class OutfitImageMap : BaseEntityMap<OutfitImage>
    {
        public OutfitImageMap() : base("OfferImage")
        {
            Property(x => x.SourceBytes).IsRequired();
            Property(x => x.ContentType).IsRequired();
        }
    }
}