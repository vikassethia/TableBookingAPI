using System;
using System.Text;
using System.Security.Cryptography;

namespace Security
{
    public class PasswordCryptography : IPasswordCryptography
    {
        public string GetPasswordHash(Guid salt, string password)
        {
            var hash = new SHA512Cng();
            var concatString = password + salt;
            var passwordByteArray = Encoding.Default.GetBytes(concatString);
            hash.ComputeHash(passwordByteArray);

            var hashPassword = Encoding.Default.GetString(hash.Hash);

            return hashPassword;
        }

    }
}
