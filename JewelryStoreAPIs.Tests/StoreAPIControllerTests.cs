using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using JewelryStoreAPIs.Tests.Shared;
using ModelLayer.EmployeeFromXML;
using Microsoft.Extensions.Configuration;
using JewelryStoreAPIs.Controllers;
using Microsoft.CodeAnalysis.Emit;
using System.Web.Http.Results;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace JewelryStoreAPIs.Tests
{
    [TestClass]
    public class StoreAPIControllerTests
    {

        private Mock<ICustomerProvider> customerProvider;
        private Mock<ILogger<StoreAPIController>> mockLogger;
        private Mock<IConfiguration> configuration;
        private StoreAPIController storeAPIController;

        [TestInitialize]
        public void TestInitialize()
        {
            this.customerProvider = HelperMethods.SetupCustomerProvider();
            this.configuration = HelperMethods.SetupConfiguration();
            this.mockLogger = HelperMethods.SetupLogger<StoreAPIController>();
            this.storeAPIController = new StoreAPIController( this.configuration.Object, this.customerProvider.Object, this.mockLogger.Object);
        }

        [TestMethod]
        public void Get_GetACustomerDetails_CorrectMatch()
        {
            var testCustomers = HelperMethods.GetTestCustomers().Where(x => x.userID=="1").FirstOrDefault();
            customerProvider.Setup(o => o.GetACustomer(It.IsAny<string>())).Returns(testCustomers);
            var controller = storeAPIController.Get("1");
            
            var result = controller as OkObjectResult;

            Assert.AreEqual(testCustomers.FirstName, ((result.Value) as Employees).FirstName);
        }

        [TestMethod]
        public void Get_GetACustomerDetails_IsNotNull()
        {
            var testCustomers = HelperMethods.GetTestCustomers().Where(x => x.userID == "1").FirstOrDefault();
            customerProvider.Setup(o => o.GetACustomer(It.IsAny<string>())).Returns(testCustomers);
            var controller = storeAPIController.Get("1");

            var result = controller as OkObjectResult;
            Assert.IsNotNull(result); //To avoid Exception
            Assert.AreEqual(testCustomers.FirstName, ((result.Value) as Employees).FirstName);
        }

        [TestMethod]
        public void Get_GetACustomerDetails_OfCorrectType()
        {
            var testCustomers = HelperMethods.GetTestCustomers().Where(x => x.userID == "1").FirstOrDefault();
            customerProvider.Setup(o => o.GetACustomer(It.IsAny<string>())).Returns(testCustomers);
            var controller = storeAPIController.Get("1");

            var result = controller as OkObjectResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(controller, typeof(OkObjectResult));
        }

        [TestMethod]
        public void Get_GetACustomerDetails_EmployeeIDNotFound_Null()
        {
            var testCustomers = HelperMethods.GetTestCustomers().Where(x => x.userID == "4").FirstOrDefault();
            customerProvider.Setup(o => o.GetACustomer(It.IsAny<string>())).Returns(testCustomers);
            var controller = storeAPIController.Get("6");

            var result = controller as NotFoundObjectResult;
            Assert.IsNull(result); 
        }

        [TestMethod]
        public void Get_GetACustomerDetails_EmployeeIDNotFound_FailureCheck()
        {

            var controller = storeAPIController.Get("6");

            var result = controller as NotFoundObjectResult;
            Assert.AreEqual(controller, typeof(OkObjectResult));
        }


        [TestMethod]
        public void Get_GetAllCustomer_EmployeeID_AllCustomers()
        {
            var testCustomers = HelperMethods.GetTestCustomers();
            //customerProvider.Setup(o => o.GetAllCustomers()).Returns(testCustomers);
            var controller = storeAPIController.Get();

            var result = controller as IEnumerable<Employees>;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Get_GetAllCustomer_EmployeeID_AllCustomersCount()
        {
            var testCustomers = HelperMethods.GetTestCustomers();
            //customerProvider.Setup(o => o.GetAllCustomers()).Returns(testCustomers);
            var controller = storeAPIController.Get();

            var result = controller as IEnumerable<Employees>;
            Assert.AreEqual(testCustomers.Count(),result.Count());
        }

        [TestMethod]
        public void Get_GetAllCustomer_EmployeeID_IsNull()
        {
            var testCustomers = HelperMethods.GetTestCustomers();
            customerProvider.Setup(o => o.GetAllCustomers());
            var controller = storeAPIController.Get();

            var result = controller as IEnumerable<Employees>;
            Assert.IsNotNull(result);
        }
    }
}
