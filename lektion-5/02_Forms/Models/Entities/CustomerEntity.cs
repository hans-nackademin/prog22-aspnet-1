using System.Security.Cryptography;
using System.Text;

namespace _02_Forms.Models.Entities
{
    public class CustomerEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public byte[] Password { get; private set; } = null!;
        public byte[] SecurityKey { get; private set; } = null!;

        public void CreateSecurePassword(string password)
        {
            using var hmac = new HMACSHA512();
            SecurityKey = hmac.Key;
            Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public bool ValidatePassword(string password)
        {
            using var hmac = new HMACSHA512(SecurityKey);
            var _hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            for(int i = 0; i < _hash.Length; i++)
            {
                if (_hash[i] != Password[i])
                    return false;
            }

            return true;    
        }
    }
}
