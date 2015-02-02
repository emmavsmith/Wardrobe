using Wardrobe.Domain.Entities;

namespace Wardrobe.Repository.EF.Mappings
{
    internal class UserMap : BaseEntityMap<User>
    {
        public UserMap() : base("User")
        {
            Property(x => x.EmailAddress).HasColumnName("EmailAddress").IsRequired().HasMaxLength(50);
            Property(x => x.Token).HasColumnName("Token").IsOptional().HasMaxLength(64);
            Property(x => x.TokenExpiry).HasColumnName("TokenExpiry").IsOptional();
            Property(x => x.PasswordKey).HasColumnName("PasswordKey").IsRequired();
            Property(x => x.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();
            Property(x => x.PasswordResetExpiry).HasColumnName("PasswordResetExpiry").IsOptional();
            Property(x => x.PasswordResetToken).HasColumnName("PasswordResetToken").IsOptional();
        }
    }
}