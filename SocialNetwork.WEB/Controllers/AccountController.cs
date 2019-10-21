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
                userBO = userBO.GetUserBOByLogin(model.UserName);
                if (userBO == null)
                {
                    userBO = mapper.Map<UserBO>(model);
                    userBO.SaveBO();
                    FormsAuthentication.SetAuthCookie(model.UserName, true);
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
                if ((user as UserBO).isValid(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, true);
                    return Redirect(returnUrl ?? Url.Action("Index", "Home"));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect User Name or Password");
                    return View();
                }
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult Main()
        {
            return View();
        }
        [Authorize]
        public ActionResult _Profile()
        {
            return PartialView();
        }
        [Authorize]
        public ActionResult Edit()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var userBO = mapper.ServiceCtor.Invoke(typeof(UserBO));
            var model = mapper.Map<UserViewModel>(userBO);
            if (id != null)
            {
                var userBOList = (userBO as UserBO).GetUserBOById(id.GetValueOrDefault());
                model = mapper.Map<UserViewModel>(userBOList);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(UserViewModel modelParam)
        {
            var userBO = mapper.Map<UserBO>(modelParam);
            if (ModelState.IsValid)
            {
                userBO.SaveBO();
                return RedirectToAction("Index", "Home");
            }
            return View(modelParam);
        }
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Main", "Home");
        }
    }
}