using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Text;

namespace JewelryStoreAPIs.Authentication
{
    public class AuthenticateUser : IAuthenticateUser
    {

        private static string XMLFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Resources\EmployeeSecrets.xml";
        private static UserSecrets UserSecrets;
        private static Dictionary<string, EmployeeSecrets> CustomerSecrets = new Dictionary<string, EmployeeSecrets>();
        public AuthenticateUser()
        {
            UserSecrets = CustomerSecrets.Count == 0 ? SharedMethods.LoadDataModel<UserSecrets>(XMLFilePath) : UserSecrets;
            CustomerSecrets = SharedMethods.GetCustomerSecret(UserSecrets);
        }

        public Dictionary<string,string> GetUserPasswordOfUser(UserSecrets users)
        {
            Dictionary<string, string> valuePairs = new Dictionary<string, string>();
            foreach (var employee in users.employees)
            {
                valuePairs.Add(employee.UserID, employee.Password);
            }
            return valuePairs;
        }

        public bool CheckValidUser(string username, string password)
        {
            bool isCorrect = false;
            if (CustomerSecrets.ContainsKey(username))
            {
                if(CustomerSecrets[username].Password == password)
                {
                    isCorrect = true;
                }
            }
            return isCorrect;
        }
    }
}
