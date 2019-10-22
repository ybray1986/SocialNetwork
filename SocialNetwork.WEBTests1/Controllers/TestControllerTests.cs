using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SocialNetwork.WEB.Controllers.Tests
{
    [TestClass()]
    public class TestControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            var controller = new TestController();
            var result = controller.Details(2) as ViewResult;
            Assert.AreEqual("Details", result.ViewName);
        }
    }
}