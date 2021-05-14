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
    public class AuthenticateUserTests
    {


        private AuthenticateUser AuthenticationUser;

        [TestInitialize]
        public void TestInitialize()
        {
           
            this.AuthenticationUser = new AuthenticateUser();
        }

    }
}
