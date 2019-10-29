using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.WEB.Controllers;
using SocialNetwork.WEB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using System.Web.Mvc;
using Ninject.Activation;
using SocialNetwork.BL.ModelBO;
using Ninject.Web.Mvc;

namespace SocialNetwork.WEB.Controllers.Tests
{
    [TestClass()]
    public class ImageControllerTests
    {
        private IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IMapper>().ToMethod(Map).InSingletonScope();
            return kernel;
        }

        private IMapper Map(IContext arg)
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void GetPostImageTest()
        {
            IKernel kernel = CreateKernel();
            System.Web.Mvc.DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            PostViewModel post = new PostViewModel
            {
                IdPost = 1,
                PostImage = new byte[] {},
                PostContent = "Some post text"
            };
            Mock<IMapper> mock = new Mock<IMapper>();
            mock.Setup(m => m.ServiceCtor.Invoke(typeof(PostViewModel))).Returns(
                new PostViewModel[]
                {
                    new PostViewModel{IdPost = 3, PostContent = "Some post text again"},
                    new PostViewModel{IdPost = 2, PostContent = "Some post text again and again"},
                    post
                }.AsQueryable()
                );
            ImageController target = new ImageController(mock.Object);
            ActionResult result = target.GetPostImage(2);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(FileResult));
            Assert.AreEqual("image/jpeg", ((FileResult)result).ContentType);
        }
    }
}