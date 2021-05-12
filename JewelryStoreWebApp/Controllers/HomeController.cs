using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JewelryStoreWebApp.Models;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using JewelryStoreWebApp.Controllers.ViewModels;
using Newtonsoft.Json;

namespace JewelryStoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IConfiguration Configuration { get; }
        private static Employee employee;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        public IActionResult Index()
        {

            string userID = string.Empty;

            if (TempData.ContainsKey("userID"))
            {
                userID = TempData["userID"] as string;
            }
            StoreViewModel storeView = new StoreViewModel();
            string customerURL = Configuration["FetchCustomerAPI"] + userID;
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(customerURL);
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(customerURL).Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {

                var data = httpResponseMessage.Content.ReadAsStringAsync().Result;

                employee = JsonConvert.DeserializeObject<Employee>(data.ToString());
                Console.WriteLine("{0}", employee);

                if(employee != null)
                {
                    storeView.userType = employee.UserType.ToString() + " User";
                    storeView.DiscountRate = employee.DiscountPercentage + " %";
                }
                //storeView
            }

            return View(storeView);
        }


        [HttpPost]
        public async Task<IActionResult> Index(StoreViewModel model)
        {
            if (ModelState.IsValid)
            {

                double goldPrice ;
                int goldPricePerGram = Convert.ToInt32(model.GoldPrice);
                int weight = Convert.ToInt32(model.Weight);
                

                goldPrice = (goldPricePerGram * weight);
                if (employee.UserType.Equals(UserType.Privileged))
                {
                    double discountMoney = (goldPrice * employee.DiscountPercentage) / 100;
                    goldPrice -= discountMoney;
                    model.TotalPrice = goldPrice.ToString();
                }
                else
                {
                    model.TotalPrice = goldPrice.ToString();
                }

            }
            return View("Index",model);
        }


        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Login(LoginViewModel model)
        //{
        //   if(model.Username != string.Empty)
        //    {
        //        return RedirectToAction(("Index", "Privacy");
        //    }
        //    return Redirect();
        //}



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }



}
