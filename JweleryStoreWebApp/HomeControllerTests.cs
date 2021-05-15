using JewelryStoreWebApp.Controllers;
using JewelryStoreWebApp.Controllers.ViewModels;
using JweleryStoreWebApp.Tests.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace JweleryStoreWebApp.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        private Mock<ILogger<HomeController>> mockLogger;
        private Mock<IConfiguration> configuration;
        private HomeController homeController;

        [TestInitialize]
        public void TestInitialize()
        {
            this.configuration = HelperMethods.SetupConfiguration();
            this.mockLogger = HelperMethods.SetupLogger<HomeController>();
            this.homeController = new HomeController(this.mockLogger.Object, this.configuration.Object) {
                TempData = HelperMethods.SetupTempData("userID", "1")
            };
        }


        [TestMethod]
        public void TestMethod1()
        {
            var httpClientFactory = new Mock<IHttpClientFactory>();
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            var employee = HelperMethods.SetupEmployee();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(@"[{ ""userID"": 1, ""FirstName"": ""Test1FirstName"" ,
""LastName"": ""Test1LastName"", ""UserType"": ""Normal"",""DiscountPercentage"":  0 }]")
                });

            var client = new HttpClient(mockHttpMessageHandler.Object);
            httpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);

            // Act  
            var controller = homeController.Index();
        }

        [TestMethod]
        public void TestMethod_PrintToScreen_ofType()
        {
            var controller = homeController.PrintToScreen(HelperMethods.GetStoreViewModel());
            Assert.IsInstanceOfType(controller,typeof(ViewResult));
        }
    }
}
