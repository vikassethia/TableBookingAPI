using DataAccess;
using Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using System.Data;

namespace BusinessLogic
{
    public class Auth : IAuth
    {
        private DataAccessClass _dataAccess;
        private TableBookingModel _context = new TableBookingModel();
        public Auth()
        {
            _dataAccess = new DataAccessClass(_context);
        }
        public bool IsUserAuthorized(string userId, string password, out user userIdentity)
        {
            var loggedInUser = _dataAccess.GetLoggedInUser(userId);
            userIdentity = loggedInUser;
            if (loggedInUser == null)
                return false;

            var passCrypto = new PasswordCryptography();
            if (loggedInUser.PasswordHash.Equals(passCrypto.GetPasswordHash(Guid.Parse(loggedInUser.Salt), password)))
            {
                return true;
            }
            return false;
        }

        public void AddNewUser(NewUserRequest userRequest)
        {
            //Check if User already registered with same User-Id

            var user = _dataAccess.GetLoggedInUser(userRequest.UserId);

            if (user != null)
                throw new DuplicateNameException("Customer already registered with this email-id");

           
            var salt = Guid.NewGuid();
            var userRole = _dataAccess.GetUserRole(userRequest.userRole);

            var passCrypto = new PasswordCryptography();
            var passwordHash = passCrypto.GetPasswordHash(salt, userRequest.Password);

           

            var newUser = new user()
            {
                UserId = userRequest.UserId,
                UserRoleID = userRole.UserRoleID,
                AddeddOn = DateTime.Now,
                IsActive = true,
                Salt = salt.ToString(),
                PasswordHash = passwordHash,
                FirstName = userRequest.FirstName,
                LastName = userRequest.LastName,
                userrole = userRole
            };          

            _dataAccess.AddNewUser(newUser);

        }

        
    }
}
