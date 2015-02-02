using System.Data.Entity.ModelConfiguration;
using Wardrobe.Domain.Entities;

namespace Wardrobe.Repository.EF.Mappings
{
    public abstract class BaseEntityMap<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {
        protected BaseEntityMap(string tableName)
        {
            this.ToTable(tableName);

            this.HasKey(t => t.Id);

            this.Property(t => t.DateCreated).IsRequired();
            this.Property(t => t.LastUpdated).IsRequired();

            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.DateCreated).HasColumnName("LastUpdated");
        }
    }
}