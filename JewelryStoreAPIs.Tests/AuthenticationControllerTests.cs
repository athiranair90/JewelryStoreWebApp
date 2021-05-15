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
using JewelryStoreAPIs.Authentication;
using NotFoundResult = Microsoft.AspNetCore.Mvc.NotFoundResult;

namespace JewelryStoreAPIs.Tests
{
    [TestClass]
    public class AuthenticationControllerTests
    {
        private Mock<IAuthenticateUser> authUsers;
        private Mock<ILogger<AuthenticationController>> mockLogger;
        private Mock<IConfiguration> configuration;
        private AuthenticationController AuthenticationController;

        [TestInitialize]
        public void TestInitialize()
        {
            this.authUsers = HelperMethods.SetupAuthenticateUser();
            this.configuration = HelperMethods.SetupConfiguration();
            this.mockLogger = HelperMethods.SetupLogger<AuthenticationController>();
            this.AuthenticationController = new AuthenticationController(this.authUsers.Object, this.mockLogger.Object);
        }

        [TestMethod]
        public void Get_GetACustomerDetails_ReturnsOkIfCorrect()
        {
            
            authUsers.Setup(o => o.CheckValidUser(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            var controller = AuthenticationController.CheckValidUser("1", "Test1");

            var result = controller as Microsoft.AspNetCore.Mvc.OkResult;

            Assert.IsInstanceOfType(controller, typeof(Microsoft.AspNetCore.Mvc.OkResult));
        }

        [TestMethod]
        public void Get_GetACustomerDetails_ReturnsNotFound_IfWrongUser()
        {
            
            authUsers.Setup(o => o.CheckValidUser(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            var controller = AuthenticationController.CheckValidUser("1", "Test1");

            var result = controller as NotFoundResult;

            Assert.IsInstanceOfType(controller, typeof(NotFoundResult));
        }

        [TestMethod]
        public void Get_GetACustomerDetails_ReturnsNotFound_NotExists()
        {

            authUsers.Setup(o => o.CheckValidUser(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            var controller = AuthenticationController.CheckValidUser("10", "Test1");

            var result = controller as NotFoundResult;

            Assert.IsInstanceOfType(controller, typeof(NotFoundResult));
        }
    }
}
