﻿using SocialNetwork.BL.ModelBO;
using SocialNetwork.WEB.Services;
using SocialNetwork.WEB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.WEB.Controllers
{
    public class UserViewModelController : Controller
    {
        // GET: UserViewModel
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(UserViewModel modelParam)
        {
            var UsersBO = NinjectDependencyResolver.Current.GetService<UsersBO>();
            UsersBO.
            using ()
        }
    }
}