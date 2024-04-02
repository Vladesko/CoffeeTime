using App.Interfaces;
using BCrypt.Net;

namespace Infastructure.Comons
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password) =>
            BCrypt.Net.BCrypt.EnhancedHashPassword(password);

        public bool Verify(string password, string PasswordHash) =>
            BCrypt.Net.BCrypt.EnhancedVerify(password, PasswordHash);
    }
}
