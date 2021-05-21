// ***********************************************************************
// Assembly         : JewelryStoreAPIs
// Author           : Athira Nair
// Created          : 05-11-2021
//
// ***********************************************************************
// <copyright file="IAuthenticateUser.cs" company="JewelryStoreAPIs">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace JewelryStoreAPIs.Authentication
{
    /// <summary>
    /// Interface IAuthenticateUser
    /// </summary>
    public interface IAuthenticateUser
    {
        /// <summary>
        /// Checks the valid user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool CheckValidUser(string username, string password);

        /// <summary>
        /// Gets the customer secret.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <returns>Dictionary&lt;System.String, EmployeeSecrets&gt;.</returns>
        public Dictionary<string, EmployeeSecrets> GetCustomerSecret(UserSecrets users);
    }
}
