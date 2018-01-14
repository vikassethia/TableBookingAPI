using DataAccess;
using Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Auth : IAuth
    {
        private DataAccessClass _dataAccess;
        public Auth()
        {
            _dataAccess = new DataAccessClass();
        }
        public bool IsUserAuthorized(string userId, string password, out User userIdentity)
        {
            var loggedInUser = _dataAccess.GetLoggedInUser(userId);
            userIdentity = loggedInUser;
            if (loggedInUser == null)
                return false;

            var passCrypto = new PasswordCryptography();
            if (loggedInUser.PasswordHash.Equals(passCrypto.GetPasswordHash(loggedInUser.Salt, password)))
            {
                return true;
            }
            return false;
        }
    }
}
