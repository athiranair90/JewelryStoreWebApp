// ***********************************************************************
// Assembly         : ModelLayer
// Author           : Athira Nair
// Created          : 05-11-2021

// ***********************************************************************
// <copyright file="CompanyCustomers.cs" company="ModelLayer">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Configuration;
using System.Reflection;

namespace ModelLayer.EmployeeFromXML
{
    /// <summary>
    /// Class CompanyCustomers.
    /// Implements the <see cref="Object" />
    /// Implements the <see cref="ModelLayer.EmployeeFromXML.ICustomerProvider" />
    /// </summary>
    /// <seealso cref="Object" />
    /// <seealso cref="ModelLayer.EmployeeFromXML.ICustomerProvider" />
    public class CompanyCustomers : ICustomerProvider
    {
        /// <summary>
        /// The customers
        /// </summary>
        private static Company Customers;
        /// <summary>
        /// The XML file path
        /// </summary>
        private static string XMLFilePath= Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Resources\Customers.xml";
        /// <summary>
        /// The customer details
        /// </summary>
        private static Dictionary<string, Employees> CustomerDetails = new Dictionary<string, Employees>();
        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyCustomers"/> class.
        /// </summary>
        public CompanyCustomers()
        {
            Customers = SharedMethods.LoadDataModel<Company>(XMLFilePath);
            CustomerDetails = SharedMethods.GetCustomerDetails(Customers);
        }

        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns>IEnumerable&lt;Employees&gt;.</returns>
        public IEnumerable<Employees> GetAllCustomers()
        {
            return Customers.Employees;
        }

        /// <summary>
        /// Gets a customer.
        /// </summary>
        /// <param name="userID">The user identifier.</param>
        /// <returns>Employees.</returns>
        public Employees GetACustomer(string userID)
        {
            if (CustomerDetails.ContainsKey(userID))
            {
                return CustomerDetails[userID];
            }
            return null;
        }
        
    }
}
