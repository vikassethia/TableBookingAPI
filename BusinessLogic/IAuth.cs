using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using Entities;

namespace BusinessLogic
{
    public interface IAuth
    {
        bool IsUserAuthorized(string userId, string password, out UserRequest userIdentity);
        void AddNewUser(UserRequest userRequest);
        void AddNewCustomer(CustomerEntity customerRequest);
        void UpdateCustomer(CustomerEntity customerRequest);
        List<CustomerEntity> GetCustomerList();
        List<UserEntity> GetUserList();
    }
}
