using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using JewelryStoreWebApp.Controllers.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace JewelryStoreWebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        public LoginController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IActionResult Index()
        {
            var model = new LoginViewModel { ReturnUrl = "Home" };
            return View("Login", model);
        }

        //[HttpGet]
        //public IActionResult Login(LoginViewModel model)
        //{
        //    model = new LoginViewModel { ReturnUrl = returnUrl };
        //    return View(model);
        //}

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
                var authenticationAPI = Configuration["LoginApi"] + @"/details?id=" + model.Username + "&Password=" + model.Password;
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(authenticationAPI);
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                // TODO:  password encode

                HttpResponseMessage httpResponseMessage = httpClient.GetAsync(authenticationAPI).Result;

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    TempData["userID"] = model.Username;
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Invalid login attempt");
            return View(model);
        }
    }
}