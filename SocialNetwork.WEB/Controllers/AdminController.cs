using AutoMapper;
using SocialNetwork.BL.ModelBO;
using SocialNetwork.WEB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.WEB.Controllers
{
    //Add some filters to get data from this controller
    //Data: Post, Delete Categories; Add, Edit, Delete User; Add, Edit, Delete Posts
    public class AdminController : Controller
    {
        IMapper mapper;
        public AdminController(IMapper mapperParam)
        {
            mapper = mapperParam;
        }
        // GET: UserViewModel
        public ActionResult Index()
        {
            var UserBO = mapper.ServiceCtor.Invoke(typeof(UserBO));
            var UserBOList = (UserBO as UserBO).GetBOListUsers();
            var model = UserBOList.Select(item => mapper.Map<UserViewModel>(item)).ToList();
            return View(model);
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
    }
}