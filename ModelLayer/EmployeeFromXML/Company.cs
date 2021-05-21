// ***********************************************************************
// Assembly         : ModelLayer
// Author           : Athira Nair
// Created          : 05-11-2021
//
// ***********************************************************************
// <copyright file="Company.cs" company="ModelLayer">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace ModelLayer.EmployeeFromXML
{
    /// <summary>
    /// Class Company.
    /// Implements the <see cref="Object" />
    /// </summary>
    /// <seealso cref="Object" />
    [Serializable]
    [XmlRoot(ElementName = "Company", DataType = "string", IsNullable = true)]
    public class Company
    {
        /// <summary>
        /// Gets or sets the employees.
        /// </summary>
        /// <value>The employees.</value>
        [XmlElement("Employee")]
        public List<Employees> Employees { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Company"/> class.
        /// </summary>
        public Company()
        {
            Employees = new List<Employees>();
        }

    }

    /// <summary>
    /// Class Employees.
    /// Implements the <see cref="Object" />
    /// </summary>
    /// <seealso cref="Object" />
    public class Employees
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        [XmlElement("userID")]
        public string userID { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [XmlElement("FirstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        [XmlElement("LastName")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the type of the user.
        /// </summary>
        /// <value>The type of the user.</value>
        [XmlElement("UserType")]
        public UserType UserType { get; set; }


        /// <summary>
        /// Gets or sets the discount percentage.
        /// </summary>
        /// <value>The discount percentage.</value>
        [XmlElement("DiscountPercentage")]
        public int DiscountPercentage { get; set; }
    }
}
