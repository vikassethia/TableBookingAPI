using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataAccessClass : IDataAccessClass
    {
        public void AddNewUser(User user)
        {
            throw new NotImplementedException();
        }

        public User GetLoggedInUser(string userId)
        {
            throw new NotImplementedException();
        }

        public UserRole GetUserRole(string userRole)
        {
            throw new NotImplementedException();
        }
    }
}
