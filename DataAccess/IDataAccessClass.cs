using System;

namespace DataAccess
{
    public interface IDataAccessClass
    {
        void AddNewUser(User user);  
        User GetLoggedInUser(string userId);
        UserRole GetUserRole(string userRole);
    }

    public class UserRole
    {
        public System.Guid UserRoleID { get; set; }
        public string UserRoleName { get; set; }

    }

    public class User
    {
        public string UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public System.Guid Salt { get; set; }
        public System.Guid UserRoleID { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime AddeddOn { get; set; }       
        public virtual UserRole UserRole { get; set; }
    }
}
