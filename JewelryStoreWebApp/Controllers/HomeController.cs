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
using JewelryStoreWebApp.Controllers.BusinessLogic;

namespace JewelryStoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IConfiguration Configuration { get; }
        internal static Employee employee;
        private static PrintViewModel printModel = new PrintViewModel();

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        public IActionResult Index()
        {

            string userID = string.Empty;
            StoreViewModel storeView = new StoreViewModel();

            if (TempData.ContainsKey("userID"))
            {
                userID = TempData["userID"] as string;
            }
            if (employee == null)
            {

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
                    ViewData["FirstName"] = employee.FirstName;

                    if (employee != null)
                    {
                        storeView.userType = employee.UserType.ToString() + " User";
                        storeView.CustomerType = employee.UserType;

                        storeView.DiscountRate = employee.DiscountPercent;
                        printModel.CustomerType = employee.UserType;
                        printModel.CustomerName = employee.FullName;
                        printModel.DiscountRate = employee.DiscountPercent;
                    }
                    //storeView
                }
            }

            return View(storeView);
        }

        [HttpPost]
        public async Task<IActionResult> Calculate(StoreViewModel model)
        {
            if (ModelState.IsValid)
            {

                double goldPrice;
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
                printModel.GoldPrice = model.GoldPrice;
                printModel.Weight = model.Weight;
                printModel.TotalPrice = model.TotalPrice;
                printModel.OuputFilePath = Configuration["OutputFilePath"];

            }
            model.CustomerType = employee.UserType;
            model.DiscountRate = employee.DiscountPercent;
            model.userType = employee.UserType.ToString() + " User";
            return View("Index", model);
        }


        public ActionResult PrintToScreen(StoreViewModel model)
        {
            model.CustomerType = employee.UserType;
            model.DiscountRate = employee.DiscountPercent;
            model.userType = employee.UserType.ToString() + " User";
            return PartialView("EmployeeOrderPartial", printModel);
        }



        public async Task<IActionResult> PrintToFile(StoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                IPrintModeFactory mode = new PrintMode();
                IPrint printData = mode.PrintModeSelector(PrintTypes.TextFile);
                printData.Print(printModel);
            }
            model.CustomerType = employee.UserType;
            model.DiscountRate = employee.DiscountPercent;
            model.userType = employee.UserType.ToString() + " User";
            return View("Index", model);
        }


        public async Task<IActionResult> PrintToPaper(StoreViewModel model)
        {
            //if (ModelState.IsValid)
            //{
                IPrintModeFactory mode = new PrintMode();
                IPrint printData = mode.PrintModeSelector(PrintTypes.PrintToFile);
                printData.Print(printModel);

            //}
            model.CustomerType = employee.UserType;
            model.DiscountRate = employee.DiscountPercent;
            model.userType = employee.UserType.ToString() + " User";
            return View("Index", model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }



}
