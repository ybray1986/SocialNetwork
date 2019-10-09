﻿using AutoMapper;
using SocialNetwork.AUTH.Entities;
using SocialNetwork.AUTH.Infrastucture;
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
        private IAuthProvider authProvider;
        public AccountController(IMapper mapperParam ,IAuthProvider authParam)
        {
            mapper = mapperParam;
            authProvider = authParam;
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = authProvider.GetUserByEmail(mapper.Map<AppUser>(model));//mapper
                if (user != null)
                {
                    authProvider.Add(user);
                    FormsAuthentication.SetAuthCookie(model.Email, true);

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
                if (authProvider.isValid(model.UserName, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}