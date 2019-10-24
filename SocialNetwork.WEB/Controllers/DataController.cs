using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialNetwork.WEB.Controllers
{
    public class DataController : ApiController
    {
        //Get Data: Search Data, Likes Data, Comments Data, Notifications Data, Categories Data
        public ActionResult Search()
        {
            var userBO = mapper.ServiceCtor(typeof(UserBO));
            var model = (userBO as UserBO).GetBOListUsers().Select(item => mapper.Map<UserViewModel>(item)).ToList();
            return PartialView(model);
        }
        public FileContentResult GetUserImage(int id)
        {
            byte[] defPhoto = System.IO.File.ReadAllBytes(Server.MapPath("~/Content/photo/Users/default/default-24.png"));
            var userBO = mapper.ServiceCtor(typeof(UserBO));
            var model = (userBO as UserBO).GetUserBOById(id);
            var userViewModel = mapper.Map<UserViewModel>(model);
            var result = (userViewModel.UserImage != null && userViewModel.UserImage.Length > 0) ? userViewModel.UserImage : defPhoto;
            return new FileContentResult(result, "image/png");
        }
        public FileContentResult GetPostImage(int id)
        {
            byte[] defPhoto = System.IO.File.ReadAllBytes(Server.MapPath("~/Content/images/pin3.jpg"));
            var postBO = mapper.ServiceCtor(typeof(PostBO));
            var model = (postBO as PostBO).GetBOPostById(id);
            var postViewModel = mapper.Map<PostViewModel>(model);
            var result = (postViewModel.PostImage != null && postViewModel.PostImage.Length > 0) ? postViewModel.PostImage : defPhoto;
            return new FileContentResult(result, "image/jpg");
        }
        public string GetUserName(int id)
        {
            var userBO = mapper.ServiceCtor(typeof(UserBO));
            var userBOList = (userBO as UserBO).GetUserBOById(id);
            var user = mapper.Map<UserViewModel>(userBOList);
            return user.UserName;
        }
        public string GetCategory(int id)
        {
            var categoryBO = mapper.ServiceCtor(typeof(CategoryBO));
            var categoryBOList = (categoryBO as CategoryBO).GetCategoryBOById(id);
            var category = mapper.Map<CategoryViewModel>(categoryBOList);
            return category.CategoryName;
        }
        public ActionResult Notification()
        {
            return PartialView();
        }
    }
}
