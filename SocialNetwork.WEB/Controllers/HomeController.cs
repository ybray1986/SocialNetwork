using AutoMapper;
using SocialNetwork.BL.ModelBO;
using SocialNetwork.WEB.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.WEB.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IMapper mapper;
        public HomeController(IMapper mapperParam)
        {
            mapper = mapperParam;
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}