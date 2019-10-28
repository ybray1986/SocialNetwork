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
    [RoutePrefix("Home/Image")]
    public class ImageController : Controller
    {
        private IMapper mapper;
        public ImageController(IMapper mapperParam)
        {
            mapper = mapperParam;
        }
        // GET: Image
        [HttpGet]
        [ActionName("User")]
        public FileContentResult GetUserImage(int id)
        {
            try
            {
                var user = mapper.ServiceCtor.Invoke(typeof(UserBO)) as UserBO;
                var userBO = user.GetUserBOById(id);
                var userViewModel = mapper.Map<UserViewModel>(userBO);
                return File(userViewModel.UserImage, "image/jpeg");
            }
            catch (Exception)
            {
                byte[] defPhoto = System.IO.File.ReadAllBytes(Server.MapPath("~/Content/photo/Users/default/default-24.png"));
                return File(defPhoto, "image/png");
            }
        }
        [HttpGet]
        [ActionName("Post")]
        public FileContentResult GetPostImage(int id)
        {
            try
            {
                var post = mapper.ServiceCtor.Invoke(typeof(PostBO)) as PostBO;
                var postBO = post.GetBOPostById(id);
                var postViewModel = mapper.Map<PostViewModel>(postBO);
                return File(postViewModel.PostImage, "image/jpeg");
            }
            catch (Exception)
            {
                byte[] defPhoto = System.IO.File.ReadAllBytes(Server.MapPath("~/Content/images/default-post-image.jpg"));
                return File(defPhoto, "image/jpeg");
            }
        }
    }
}