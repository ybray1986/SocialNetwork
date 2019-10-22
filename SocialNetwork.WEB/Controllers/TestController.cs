using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.WEB.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        //Make Some complicated tests
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(int Id)
        {
            return View("Details");
        }
    }
}