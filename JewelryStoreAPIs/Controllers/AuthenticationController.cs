// ***********************************************************************
// Assembly         : JewelryStoreAPIs
// Author           : Athira Nair
// Created          : 05-11-2021
//
// ***********************************************************************
// <copyright file="AuthenticationController.cs" company="JewelryStoreAPIs">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using JewelryStoreAPIs.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JewelryStoreAPIs.Controllers
{
    /// <summary>
    /// Class AuthenticationController.
    /// Implements the <see cref="ControllerBase" />
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        /// <summary>
        /// The authenticate user
        /// </summary>
        private IAuthenticateUser _authenticateUser;
        /// <summary>
        /// The logger
        /// </summary>
        ILogger<AuthenticationController> _logger;
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationController"/> class.
        /// </summary>
        /// <param name="authenticateUser">The authenticate user.</param>
        /// <param name="logger">The logger.</param>
        public AuthenticationController(IAuthenticateUser authenticateUser, ILogger<AuthenticationController> logger)
        {
            this._authenticateUser = authenticateUser;
            this._logger = logger;
        }


        // GET: api/StoreAPI/5
        /// <summary>
        /// Checks the valid user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="password">The password.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet("details")]
        public IActionResult CheckValidUser(string id, string password)
        {
            if (_authenticateUser.CheckValidUser(id, password))
            {
                return Ok();
            }
            return NotFound();
        }

        //// GET: api/StoreAPI/5
        //[HttpGet("{id}/{password}", Name = "CheckUser")]
        //public ActionResult CheckValidUser1(string id, string password)
        //{
        //    Employees emp = new Employees();
        //    if (_authenticateUser.CheckValidUser(id, password))
        //    {
        //        emp = customerProvider.GetACustomer(id);
        //    }
        //    return emp;
        //}


    }
}