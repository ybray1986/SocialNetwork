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
        public ActionResult Notification()
        {
            return PartialView("_Notification");
        }
        public ActionResult AddContent()
        {
            return PartialView("_AddContent");
        }
        public ActionResult Search()
        {
            var userBO = mapper.ServiceCtor(typeof(UserBO));
            var model = (userBO as UserBO).GetBOListUsers().Select(item=>mapper.Map<UserViewModel>(item)).ToList();
            return PartialView("_Search", model);
        }
        public FileContentResult GetImage(int id)
        {
            byte[] defPhoto = System.IO.File.ReadAllBytes(Server.MapPath("~/Content/photo/Users/default/default-24.png"));
            var userBO = mapper.ServiceCtor(typeof(UserBO));
            var model = (userBO as UserBO).GetUserBOById(id);
            var userViewModel = mapper.Map<UserViewModel>(model);
            return new FileContentResult((userViewModel.UserImage != null && userViewModel.UserImage.Length > 0) ? userViewModel.UserImage : defPhoto, "image/png");
        }
    }
}