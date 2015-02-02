using Wardrobe.Domain.Entities;

namespace Wardrobe.Repository.EF.Mappings
{
    internal class OutfitMap : BaseEntityMap<Outfit>
    {
        public OutfitMap() : base("Outfit")
        {
            Property(x => x.Name).HasColumnName("Name").IsRequired();

            HasOptional(x => x.Image).WithMany().HasForeignKey(x => x.ImageId).WillCascadeOnDelete(false);
            HasRequired(x => x.User).WithMany().HasForeignKey(x => x.UserId).WillCascadeOnDelete(false);
            HasMany(x => x.OutfitItems).WithRequired().HasForeignKey(x => x.OutfitId);
        }
    }
}