using AutoMapper;
using SocialNetwork.BL.ModelBO;
using SocialNetwork.WEB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SocialNetwork.WEB.Controllers
{
    public class DataController : ApiController
    {
        private IMapper mapper;
        public DataController(IMapper mapperParam)
        {
            mapper = mapperParam;
        }
        //
        //Get Data: Search Data(Get), Likes Data(Get, Post), Comments Data(Get, Post), Notifications Data(Get), Categories Data(Get)
        //
        //public ActionResult Search()
        //{
        //    var userBO = mapper.ServiceCtor(typeof(UserBO));
        //    var model = (userBO as UserBO).GetBOListUsers().Select(item => mapper.Map<UserViewModel>(item)).ToList();
        //    return PartialView(model);
        //}
        //public FileContentResult GetUserImage(int id)
        //{
        //    byte[] defPhoto = System.IO.File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/Content/photo/Users/default/default-24.png"));
        //    var userBO = mapper.ServiceCtor(typeof(UserBO));
        //    var model = (userBO as UserBO).GetUserBOById(id);
        //    var userViewModel = mapper.Map<UserViewModel>(model);
        //    var result = (userViewModel.UserImage != null && userViewModel.UserImage.Length > 0) ? userViewModel.UserImage : defPhoto;
        //    return new FileContentResult(result, "image/png");
        //}
        
        public string GetUserName(int id)
        {
            var userBO = mapper.ServiceCtor(typeof(UserBO));
            var userBOList = (userBO as UserBO).GetUserBOById(id);
            var user = mapper.Map<UserViewModel>(userBOList);
            return user.UserName;
        }
        [HttpPost]
        public IHttpActionResult GetCategoryList()
        {
            try
            {
                var categoryBO = mapper.ServiceCtor(typeof(CategoryBO));
                var categoryViewModelList = (categoryBO as CategoryBO).CategoryBOList().Select(model => mapper.Map<CategoryViewModel>(model)).ToList();
                return Ok(categoryViewModelList);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        public string GetCategory(int id)
        {
            var categoryBO = mapper.ServiceCtor(typeof(CategoryBO));
            var categoryBOList = (categoryBO as CategoryBO).GetCategoryBOById(id);
            var category = mapper.Map<CategoryViewModel>(categoryBOList);
            return category.CategoryName;
        }
    }
}
