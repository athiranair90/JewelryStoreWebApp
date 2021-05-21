// ***********************************************************************
// Assembly         : ModelLayer
// Author           : Athira Nair
// Created          : 05-11-2021
//
// ***********************************************************************
// <copyright file="ICustomerProvider.cs" company="ModelLayer">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.EmployeeFromXML
{
    /// <summary>
    /// Interface ICustomerProvider
    /// </summary>
    public interface ICustomerProvider
    {
        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns>IEnumerable&lt;Employees&gt;.</returns>
        public IEnumerable<Employees> GetAllCustomers();
        /// <summary>
        /// Gets a customer.
        /// </summary>
        /// <param name="userID">The user identifier.</param>
        /// <returns>Employees.</returns>
        public Employees GetACustomer(string userID);

    }
}
