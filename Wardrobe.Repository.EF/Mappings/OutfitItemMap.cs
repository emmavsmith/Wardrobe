using Wardrobe.Domain.Entities;

namespace Wardrobe.Repository.EF.Mappings
{
    internal class OutfitItemMap : BaseEntityMap<OutfitItem>
    {
        public OutfitItemMap() : base("OutfitItem")
        {
            HasKey(x => new 
            {
                x.ItemId,
                x.OutfitId
            });
        }
    }
}