using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JewelryStoreWebApp.Controllers.ViewModels;
using JewelryStoreWebApp.Controllers;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace JweleryStoreWebApp.Tests.Shared
{
    public class HelperMethods
    {

        //Generic mock method
        public static Mock<ILogger<T>> SetupLogger<T>() where T : class
        {
            Mock<ILogger<T>> result = new Mock<ILogger<T>>();
            //result.Setup(o => o.LogInformation(It.IsAny<string>()));
            //result.Setup(o => o.LogError(It.IsAny<string>()));
            //result.Setup(o => o.LogWarning(It.IsAny<string>()));

            return result;
        }

        public static Employee SetupEmployee() 
        {
            var result = new Employee { userID = "1", FirstName = "Test1FirstName", LastName = "Test1LastName", UserType = UserType.Normal, DiscountPercentage = 0 };
            return result;
        }

        public static TempDataDictionary SetupTempData(string key,string value)
        {
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            tempData[key] = value;

            return tempData;
        }

        
        public static Mock<IConfiguration> SetupConfiguration()
        {

            Mock<IConfiguration> config = new Mock<IConfiguration>();
            config.Setup(O => O["FetchCustomerAPI"]).Returns("https://localhost:44303/api/StoreAPI/");
            return config;
        }



        public static StoreViewModel GetStoreViewModel()
        {
            var viewModel = new StoreViewModel();
            viewModel.CustomerType = UserType.Privileged;
            viewModel.GoldPrice = "10";
            viewModel.TotalPrice = "20";
            viewModel.userType = UserType.Privileged +" User";
            viewModel.Weight = "2";
            viewModel.DiscountRate = "2";
            return viewModel;
        }

        public static PrintViewModel GetPrintViewModel()
        {
            var viewModel = new PrintViewModel();
            viewModel.CustomerType = UserType.Privileged;
            viewModel.GoldPrice = "10";
            viewModel.TotalPrice = "20";
            viewModel.userType = UserType.Privileged + " User";
            viewModel.Weight = "2";
            viewModel.DiscountRate = "2";
            viewModel.CustomerName = "Test";
            return viewModel;
        }
    }
}
