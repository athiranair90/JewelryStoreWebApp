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
    [Route("api/[controller]")]
    [ApiController]
    public class StoreAPIController : ControllerBase
    {

        IConfiguration configuration;
        ICustomerProvider customerProvider;
        ILogger<StoreAPIController> _logger;

        public StoreAPIController(IConfiguration configuration, ICustomerProvider customerProvider, ILogger<StoreAPIController> logger)
        {

            this.configuration = configuration;
            this.customerProvider = customerProvider;
            this._logger = logger;
        }

        // GET: api/StoreAPI
        [HttpGet]
        public IEnumerable<Employees> Get()
        {
            return customerProvider.GetAllCustomers();
        }

        // GET: api/StoreAPI/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(string id)
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


        #region Later 
        //// POST: api/StoreAPI
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/StoreAPI/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        #endregion
    }
}
