using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SocialNetwork.WEB.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.WEB.Controllers
{
    public class LoginViewModelController : Controller
    {
        // GET: LoginViewModel
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
                var authManager = HttpContext.GetOwinContext().Authentication;

                AppUser user = userManager.Find(login.UserName, login.Password);
                if (user != null)
                {
                    var ident = userManager.CreateIdentity(user,
                        DefaultAuthenticationTypes.ApplicationCookie);
                    //use the instance that has been created. 
                    authManager.SignIn(
                        new AuthenticationProperties { IsPersistent = false }, ident);
                    return Redirect(login.ReturnUrl ?? Url.Action("Index", "Home"));
                }
            }
            ModelState.AddModelError("", "Invalid username or password");
            return View(login);
        }
        public ActionResult CreateRole(string roleName)
        {
            var roleManager = HttpContext.GetOwinContext().GetUserManager<RoleManager<AppRole>>();

            if (!roleManager.RoleExists(roleName))
                roleManager.Create(new AppRole(roleName));
            // rest of code
            return View();
        }
    }
}