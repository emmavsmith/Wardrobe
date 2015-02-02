using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Wardrobe.Domain.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            // Parameterless constructor for EF
        }

        public User(string emailAddress, string password)
        {
            EmailAddress = emailAddress;
            SetPassword(password);
        }

        public string EmailAddress { get; set; }
        public string Token { get; set; }
        public DateTime TokenExpiry { get; set; }
        public byte[] PasswordKey { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string PasswordResetToken { get; set; }
        public DateTime? PasswordResetExpiry { get; set; }
        public byte[] PasscodeKey { get; set; }
        public byte[] PasscodeSalt { get; set; }

        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<Outfit> Outfits { get; set; }

        public string GenerateToken(int minutesExpiresIn)
        {
            Token = Guid.NewGuid().ToString("N");
            TokenExpiry = DateTime.UtcNow.AddMinutes(minutesExpiresIn);
            return Token;
        }

        public bool SetPassword(string newPassword)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(newPassword, 64))
            {
                var newKey = deriveBytes.GetBytes(64);
                return newKey.SequenceEqual(PasswordKey);
            }
        }

        public bool PasswordIsValid(string password)
        {
            using (var derivedBytes = new Rfc2898DeriveBytes(password, PasscodeSalt))
            {
                var newKey = derivedBytes.GetBytes(64);
                return newKey.SequenceEqual(PasscodeKey);
            }
        }
    }
}