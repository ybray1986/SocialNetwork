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
using Ninject;

namespace SocialNetwork.WEB.Controllers
{
    public class ContentController : ApiController
    {
        //Get Data: Add, Edit, Delete posts. Get all UserName Post to Index
        //Get Posts From Followers
        //View Posts from Users of Search list
        //Posts count
        private IMapper mapper;
        public ContentController(IMapper mapperParam)
        {
            mapper = mapperParam;
        }
        //[HttpGet]
        //public void AddContent()
        //{
        //    var categoryBO = mapper.ServiceCtor.Invoke(typeof(CategoryBO));
        //    var categoryBOList = (categoryBO as CategoryBO).CategoryBOList();
        //    var categoryViewModelList = mapper.Map<List<CategoryViewModel>>(categoryBOList);
        //    ViewBag.CategoryList = new SelectList(categoryViewModelList, "IdCategory", "CategoryName");
        //    return PartialView();
        //}
        [HttpGet]
        public HttpResponseMessage GetPostImage()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [HttpGet]
        public HttpResponseMessage GetPostImage(int id)
        {
            byte[] defPhoto = System.IO.File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/Content/images/pin3.jpg"));
            var postBO = mapper.ServiceCtor(typeof(PostBO));
            var model = (postBO as PostBO).GetBOPostById(id);
            var postViewModel = mapper.Map<PostViewModel>(model);
            var result = (postViewModel.PostImage != null && postViewModel.PostImage.Length > 0) ? postViewModel.PostImage : defPhoto;
            return Request.CreateResponse(result);
            //return new FileContentResult(result, "image/jpg");
        }
        [HttpPost]
        public void CreateContent([FromBody]PostViewModel postParam, HttpPostedFileBase image)
        {
            //var userBO = mapper.ServiceCtor.Invoke(typeof(UserBO));
            //var userBOList = (userBO as UserBO).GetUserBOByLogin(User.Identity.Name);
            //var userViewModel = mapper.Map<UserViewModel>(userBOList);
            //postParam.IdUser = userViewModel.IdUser;
            //if (image != null)
            //{
            //    postParam.PostImage = new byte[image.ContentLength];
            //    image.InputStream.Read(postParam.PostImage, 0, image.ContentLength);
            //}
            //else
            //{

            //    byte[] defPhoto = System.IO.File.ReadAllBytes(Server.MapPath("~/Content/images/default-post-image.jpg"));
            //    postParam.PostImage = new byte[Buffer.ByteLength(defPhoto)];
            //    postParam.PostImage = defPhoto;
            //}
            var post = mapper.Map<PostBO>(postParam);
            post.SaveBO();
            //return RedirectToAction("Index");
        }
        //public ActionResult GetCurrentUserIdPosts()
        //{
        //    var userBO = mapper.ServiceCtor.Invoke(typeof(UserBO));
        //    var userBOList = (userBO as UserBO).GetUserBOByLogin(User.Identity.Name);
        //    var userViewModel = mapper.Map<UserViewModel>(userBOList);
        //    var userId = userViewModel.IdUser;
        //    var postBO = mapper.ServiceCtor.Invoke(typeof(PostBO));
        //    var postsBOUser = (postBO as PostBO).GetBOAllPostsByUserId(userId);
        //    var postsViewModelList = postsBOUser.Select(model => mapper.Map<PostViewModel>(model)).ToList();
        //    return PartialView("Posts", postsViewModelList);
        //}
    }
}
