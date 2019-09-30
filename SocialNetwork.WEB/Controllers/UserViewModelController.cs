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
    public class UserViewModelController : Controller
    {
        IMapper mapper;
        public UserViewModelController(IMapper mapperParam)
        {
            mapper = mapperParam;
        }
        // GET: UserViewModel
        public ActionResult Index()
        {
            var UserBO = DependencyResolver.Current.GetService<UserBO>();
            var UserBOList = UserBO.GetListUsers();
            var model = UserBOList.Select(item => mapper.Map<UserViewModel>(item)).ToList();
            return View(model);
        }
        //[HttpGet]
        //public ActionResult Edit(UserViewModel modelParam)
        //{
        //    //var UsersBO = DependencyResolver.Current.GetService<UsersBO>();
        //    //UsersBO.
        //    //using ()
        //}
    }
}