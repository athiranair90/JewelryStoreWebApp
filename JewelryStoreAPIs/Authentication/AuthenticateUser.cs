// ***********************************************************************
// Assembly         : JewelryStoreAPIs
// Author           : Athira Nair
// Created          : 05-11-2021
//
// ***********************************************************************
// <copyright file="AuthenticateUser.cs" company="JewelryStoreAPIs">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Text;

namespace JewelryStoreAPIs.Authentication
{
    /// <summary>
    /// Class AuthenticateUser.
    /// Implements the <see cref="Object" />
    /// Implements the <see cref="JewelryStoreAPIs.Authentication.IAuthenticateUser" />
    /// </summary>
    /// <seealso cref="Object" />
    /// <seealso cref="JewelryStoreAPIs.Authentication.IAuthenticateUser" />
    public class AuthenticateUser : IAuthenticateUser
    {

        /// <summary>
        /// The XML file path
        /// </summary>
        private static string XMLFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Authentication\Resource\EmployeeSecrets.xml";
        /// <summary>
        /// The user secrets
        /// </summary>
        private static UserSecrets UserSecrets;
        /// <summary>
        /// The customer secrets
        /// </summary>
        internal static Dictionary<string, EmployeeSecrets> CustomerSecrets = new Dictionary<string, EmployeeSecrets>();
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticateUser"/> class.
        /// </summary>
        public AuthenticateUser()
        {
            UserSecrets = CustomerSecrets.Count == 0 ? SharedMethods.LoadDataModel<UserSecrets>(XMLFilePath) : UserSecrets;
            CustomerSecrets = GetCustomerSecret(UserSecrets);
        }

        /// <summary>
        /// Gets the user password of user.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <returns>Dictionary&lt;System.String, System.String&gt;.</returns>
        public Dictionary<string,string> GetUserPasswordOfUser(UserSecrets users)
        {
            Dictionary<string, string> valuePairs = new Dictionary<string, string>();
            foreach (var employee in users.employees)
            {
                valuePairs.Add(employee.UserID, employee.Password);
            }
            return valuePairs;
        }

        /// <summary>
        /// Checks the valid user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
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

        /// <summary>
        /// Gets the customer secret.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <returns>Dictionary&lt;System.String, EmployeeSecrets&gt;.</returns>
        public Dictionary<string, EmployeeSecrets> GetCustomerSecret(UserSecrets users)
        {
            Dictionary<string, EmployeeSecrets> valuePairs = new Dictionary<string, EmployeeSecrets>();
            foreach (EmployeeSecrets employee in users.employees)
            {
                valuePairs.Add(employee.UserID, employee);
            }
            return valuePairs;
        }

    }
}
