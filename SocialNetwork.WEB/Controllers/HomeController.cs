using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.WEB.Controllers
{
    public class HomeController : Controller
    {
        //Page of user
        // GET: Home
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Result = User.Identity.Name;
            }
            else
            {
                ViewBag.Result = "You are not logged in!";
            }
            return View();
        }
    }
}