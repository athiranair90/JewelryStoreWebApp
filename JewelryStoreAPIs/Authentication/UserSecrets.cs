// ***********************************************************************
// Assembly         : JewelryStoreAPIs
// Author           : Athira Nair
// Created          : 05-11-2021
//
// ***********************************************************************
// <copyright file="UserSecrets.cs" company="JewelryStoreAPIs">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace JewelryStoreAPIs.Authentication
{
    /// <summary>
    /// Class UserSecrets.
    /// Implements the <see cref="Object" />
    /// </summary>
    /// <seealso cref="Object" />
    [XmlRoot("UserSecrets")]
    public class UserSecrets
    {
        /// <summary>
        /// The employees
        /// </summary>
        [XmlElement("Employee")]
        public List<EmployeeSecrets> employees;

    }

    /// <summary>
    /// Class EmployeeSecrets.
    /// Implements the <see cref="Object" />
    /// </summary>
    /// <seealso cref="Object" />
    public class EmployeeSecrets
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        [XmlElement("userID")]
        public string UserID { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        [XmlElement("Password")]
        public string Password { get; set; }
    }
}
