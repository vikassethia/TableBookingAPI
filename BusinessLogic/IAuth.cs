using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;

namespace BusinessLogic
{
    public interface IAuth
    {
        bool IsUserAuthorized(string userId, string password, out user userIdentity);
        void AddNewUser(NewUserRequest userRequest);
    }
}
