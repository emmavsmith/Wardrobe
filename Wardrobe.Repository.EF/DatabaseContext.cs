using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Wardrobe.Domain.Entities;
using Wardrobe.Repository.EF.Mappings;

namespace Wardrobe.Repository.EF
{
    public class DatabaseContext : DbContext
    {
        static DatabaseContext()
        {
            Database.SetInitializer<DatabaseContext>(null);
        }

        public DatabaseContext() : base("Name=DatabaseContext")
        {
            Configuration.AutoDetectChangesEnabled = true;
        }

        public virtual IDbSet<Outfit> Outfits { get; set; }
        public virtual IDbSet<Item> Items { get; set; }
        public virtual IDbSet<OutfitItem> OutfitItems { get; set; }
        public virtual IDbSet<OutfitImage> OutfitImage { get; set; }
        public virtual IDbSet<ItemImage> ItemImage { get; set; }
        public virtual IDbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new OutfitMap());
            modelBuilder.Configurations.Add(new ItemMap());
            modelBuilder.Configurations.Add(new OutfitItemMap());
            modelBuilder.Configurations.Add(new OutfitImageMap());
            modelBuilder.Configurations.Add(new ItemImageMap());
            modelBuilder.Configurations.Add(new UserMap());
        }

        public void Seed()
        {
        }
    }
}