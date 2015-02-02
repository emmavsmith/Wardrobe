using Wardrobe.Domain.Entities;

namespace Wardrobe.Repository.EF.Mappings
{
    internal class ItemMap : BaseEntityMap<Item>
    {
        public ItemMap() : base("Item")
        {
            Property(x => x.Name).HasColumnName("Name").IsRequired();
            Property(x => x.Category).HasColumnName("Category").IsRequired();

            HasOptional(x => x.Image).WithMany().HasForeignKey(x => x.ImageId).WillCascadeOnDelete(false);
            HasRequired(x => x.User).WithMany().HasForeignKey(x => x.UserId).WillCascadeOnDelete(false);
            HasMany(x => x.OutfitItems).WithRequired().HasForeignKey(x => x.ItemId);
        }
    }
}