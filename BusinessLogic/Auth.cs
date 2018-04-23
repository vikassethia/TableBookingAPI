using DataAccess;
using Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using System.Data;
using Entities;

namespace BusinessLogic
{
    public class Auth : IAuth
    {
        private DataAccessClass _dataAccess;
        private TableBookingModel _context = new TableBookingModel();
        private string _customerId = string.Empty;
        public Auth()
        {
            _dataAccess = new DataAccessClass(_context);
        }

        public Auth(string customerId)
        {
            _customerId = customerId;
            _dataAccess = new DataAccessClass(_context, customerId);
        }

        public bool IsUserAuthorized(string userId, string password, out UserRequest userIdentity)
        {
            var loggedInUser = _dataAccess.GetLoggedInUser(userId);
            userIdentity = new UserRequest() {
                FirstName=loggedInUser.FirstName,
                LastName = loggedInUser.LastName,
                UserId = loggedInUser.UserId,
                CustomerId= loggedInUser.CustomerId,
                UserRole = loggedInUser.userrole.UserRoleName
            };
            if (loggedInUser == null)
                return false;

            var passCrypto = new PasswordCryptography();
            if (loggedInUser.PasswordHash.Equals(passCrypto.GetPasswordHash(Guid.Parse(loggedInUser.Salt), password)))
            {
                return true;
            }
            return false;
        }

        public void AddNewUser(UserRequest userRequest)
        {
            //Check if User already registered with same User-Id

            var user = _dataAccess.GetLoggedInUser(userRequest.UserId);

            if (user != null)
                throw new DuplicateNameException("Customer already registered with this email-id");

           
            var salt = Guid.NewGuid();
            var userRole = _dataAccess.GetUserRole(userRequest.UserRole);

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
                CustomerId=userRequest.CustomerId,
                userrole = userRole
            };          

            _dataAccess.AddNewUser(newUser);

        }

        public void AddNewCustomer(CustomerEntity customerRequest)
        {
            //Check if User already registered with same User-Id

            var existingCustomer = _dataAccess.GetLoggedInCustomer(customerRequest.CustomerId);

            if (existingCustomer != null)
                throw new DuplicateNameException("Customer already registered with this id");      


            var newCustomer = new customer()
            {
               AddeddOn = DateTime.Now,
               Address = customerRequest.Address,
               CompanyName= customerRequest.CompanyName,
               CustomerId = customerRequest.CustomerId,
               DisplayName= customerRequest.DisplayName,
               IsActive = customerRequest.IsActive               
            };

            _dataAccess.AddNewCustomer(newCustomer);
        }


        public void UpdateCustomer(CustomerEntity customerRequest)
        {         

            var newCustomer = new customer()
            {
                Address = customerRequest.Address,
                CompanyName = customerRequest.CompanyName,
                CustomerId = customerRequest.CustomerId,
                DisplayName = customerRequest.DisplayName,
                IsActive = customerRequest.IsActive
            };

            _dataAccess.UpdateCustomer(newCustomer);
        }

        public List<CustomerEntity> GetCustomerList()
        {
            var customerList = _dataAccess.GetCustomerList();

            var response = new List<CustomerEntity>();

            foreach (var customer in customerList)
            {
                response.Add(
                    new CustomerEntity()
                    {
                        CustomerId = customer.CustomerId,
                        CompanyName = customer.CompanyName,
                        DisplayName = customer.DisplayName,
                        Address = customer.Address,
                        IsActive = customer.IsActive
                    }
                    );
            }


            return response;
        }

        public List<UserEntity> GetUserList()
        {
            var userList = _dataAccess.GetUserList();

            var response = new List<UserEntity>();

            foreach (var userItem in userList)
            {
                response.Add(
                    new UserEntity()
                    {
                        UserId = userItem.UserId,
                        CustomerName = userItem.customer.DisplayName,
                        FirstName = userItem.FirstName,
                        LastName = userItem.LastName,
                        UserRole = userItem.userrole.UserRoleName
                    }
                    );
            }


            return response;
        }
    }
}
