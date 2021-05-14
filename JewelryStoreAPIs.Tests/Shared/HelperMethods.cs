using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using ModelLayer.EmployeeFromXML;
using Microsoft.Extensions.Configuration;
using System.Linq;
using JewelryStoreAPIs.Controllers;
using JewelryStoreAPIs.Authentication;

namespace JewelryStoreAPIs.Tests.Shared
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

        public static Mock<ICustomerProvider> SetupCustomerProvider()
        {
            var customers = GetTestCustomers();
            Mock<ICustomerProvider> provider = new Mock<ICustomerProvider>();
            provider.Setup(o => o.GetAllCustomers()).Returns(customers);
            provider.Setup(o => o.GetACustomer(It.IsAny<string>())).Returns((Employees myval) => { return myval; });
            return provider;
        }
        public static Mock<IAuthenticateUser> SetupAuthenticateUser()
        {
            var userSecrets = GetTestUserSecrects();
            Mock<IAuthenticateUser> userAuthentication = new Mock<IAuthenticateUser>();
            userAuthentication.Setup(o => o.CheckValidUser(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            userAuthentication.Setup(o => o.GetCustomerSecret(It.IsAny<UserSecrets>())).Returns(userSecrets);
            return userAuthentication;
        }
        public static Mock<IConfiguration> SetupConfiguration()
        {

            Mock<IConfiguration> config = new Mock<IConfiguration>();
            
            return config;
        }



        public static IEnumerable<Employees> GetTestCustomers()
        {
            var testEmployee = new List<Employees>();
            testEmployee.Add(new Employees { userID = "1", FirstName = "Test1FirstName", LastName = "Test1LastName", UserType = UserType.Normal, DiscountPercentage = 0 });
            testEmployee.Add(new Employees { userID = "1", FirstName = "Test2FirstName", LastName = "Test2LastName", UserType = UserType.Privileged, DiscountPercentage = 2 });
            testEmployee.Add(new Employees { userID = "1", FirstName = "Test3FirstName", LastName = "Test3LastName", UserType = UserType.Privileged, DiscountPercentage = 5 });

            return testEmployee;
        }

        public static Dictionary<string, EmployeeSecrets> GetTestUserSecrects()
        {
            var testEmployeeSecret = new Dictionary<string, EmployeeSecrets>();
            testEmployeeSecret.Add("1",new EmployeeSecrets { UserID = "1", Password = "Test1"});
            testEmployeeSecret.Add("2",new EmployeeSecrets { UserID = "2", Password = "Test2"});
            testEmployeeSecret.Add("3",new EmployeeSecrets { UserID = "3", Password = "Test3"});

            return testEmployeeSecret;
        }
    }
}
