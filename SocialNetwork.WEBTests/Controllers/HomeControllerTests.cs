using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using AutoMapper;

namespace SocialNetwork.WEB.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {

        [TestMethod()]
        public void AddContentTest()
        {
            var repo = new Mock<IMapper>();
            repo.Setup(d => d.ServiceCtor.Invoke(typeof(HomeControllerTests)));
            var controller = new HomeController(repo);
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}