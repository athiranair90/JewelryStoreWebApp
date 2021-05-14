using System;
using System.Collections.Generic;
using System.Text;

namespace JewelryStoreAPIs.Authentication
{
    public interface IAuthenticateUser
    {
        public bool CheckValidUser(string username, string password);

        public Dictionary<string, EmployeeSecrets> GetCustomerSecret(UserSecrets users);
    }
}
