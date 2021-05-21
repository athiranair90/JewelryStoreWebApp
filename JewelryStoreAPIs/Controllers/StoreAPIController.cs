// ***********************************************************************
// Assembly         : JewelryStoreAPIs
// Author           : Athira Nair
// Created          : 05-11-2021
//
// ***********************************************************************
// <copyright file="StoreAPIController.cs" company="JewelryStoreAPIs">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using Microsoft.Extensions.Configuration;
using System.Xml;
using Microsoft.Extensions.Logging;
using ModelLayer.EmployeeFromXML;
using JewelryStoreAPIs.Authentication;
using System.Net.Http;

namespace JewelryStoreAPIs.Controllers
{
    /// <summary>
    /// Class StoreAPIController.
    /// Implements the <see cref="ControllerBase" />
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class StoreAPIController : ControllerBase
    {

        /// <summary>
        /// The configuration
        /// </summary>
        IConfiguration configuration;
        /// <summary>
        /// The customer provider
        /// </summary>
        ICustomerProvider customerProvider;
        /// <summary>
        /// The logger
        /// </summary>
        ILogger<StoreAPIController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreAPIController"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="customerProvider">The customer provider.</param>
        /// <param name="logger">The logger.</param>
        public StoreAPIController(IConfiguration configuration, ICustomerProvider customerProvider, ILogger<StoreAPIController> logger)
        {

            this.configuration = configuration;
            this.customerProvider = customerProvider;
            this._logger = logger;
        }

        // GET: api/StoreAPI
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>IEnumerable&lt;Employees&gt;.</returns>
        [HttpGet]
        public IEnumerable<Employees> Get()
        {
            return customerProvider.GetAllCustomers();
        }

        // GET: api/StoreAPI/5
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(string id)
        {
            Employees emp = new Employees();

            emp = customerProvider.GetACustomer(id);
            if(emp != null)
            {
                return Ok(emp);
            }
            return NotFound();
        }


        //// GET: api/StoreAPI/5
        //[HttpGet("{id}", Name = "CalculatePrice")]//from body fetch these 2 data
        //public double CalculatePrice(string id)
        //{
        //    Employees emp = customerProvider.GetACustomer(id);
        //    double goldPrice = 0;
        //    int goldPricePerGram = 0;
        //    int weight = 0;
        //    int discountMoney = emp.DiscountPercentage / 100;

        //    goldPrice = (goldPricePerGram * weight);
        //    if (emp.UserType.Equals(UserType.Privileged))
        //    {
        //        goldPrice -= goldPrice * discountMoney;
        //    }
        //    return goldPrice;
        //}


    }
}
