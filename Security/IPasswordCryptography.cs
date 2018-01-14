using System;

namespace Security
{
   public interface IPasswordCryptography
   {
       string GetPasswordHash(Guid salt, string password);
   }
}
