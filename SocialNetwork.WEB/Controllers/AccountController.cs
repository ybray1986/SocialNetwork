using AutoMapper;
using SocialNetwork.BL.ModelBO;
using SocialNetwork.WEB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SocialNetwork.WEB.Controllers
{
    public class AccountController : Controller
    {
        private IMapper mapper;
        public AccountController(IMapper mapperParam)
        {
            mapper = mapperParam;
        }
        public ActionResult Register()
        {
            return View();
        }
        //On register add default photo to form in view
        [HttpPost]
        public ActionResult Register(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userBO = mapper.Map<UserBO>(model);
                userBO.GetUserBOByEmail(model.Email);
                if (userBO == null)
                {
                    userBO.SaveBO();
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login is exist!");
                }
            }
            return View(model);
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = mapper.ServiceCtor.Invoke(typeof(UserBO));
                if ((user as UserBO).isValid(model.Email, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return Redirect(returnUrl ?? Url.Action("Index", "Home"));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}