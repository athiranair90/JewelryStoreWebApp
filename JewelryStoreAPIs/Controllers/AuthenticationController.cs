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
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticateUser _authenticateUser;
        ILogger<AuthenticationController> _logger;
        public AuthenticationController(IAuthenticateUser authenticateUser, ILogger<AuthenticationController> logger)
        {
            this._authenticateUser = authenticateUser;
            this._logger = logger;
        }


        // GET: api/StoreAPI/5
        [HttpGet("details")]
        public HttpResponseMessage CheckValidUser(string id, string password)
        {
            if (_authenticateUser.CheckValidUser(id, password))
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
                //Request.CreateResponse(HttpStatusCode.OK, stud);
                //ret = customerProvider.GetACustomer(id);
            }
            return new HttpResponseMessage(HttpStatusCode.NotFound);
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