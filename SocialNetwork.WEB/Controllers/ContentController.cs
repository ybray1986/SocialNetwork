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
using Ninject.Web.WebApi;
using System.Drawing;
using System.IO;

namespace SocialNetwork.WEB.Controllers
{
    [RoutePrefix("Home/web/Content")]
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
        [HttpGet]
        [ActionName("Content")]
        public IHttpActionResult GetAllContent()
        {
            try
            {
                var user = mapper.ServiceCtor.Invoke(typeof(UserBO));
                var userBO = (user as UserBO).GetUserBOByLogin(User.Identity.Name);
                var userViewModel = mapper.Map<UserViewModel>(userBO);
                var postBOInst = mapper.ServiceCtor.Invoke(typeof(PostBO));
                var postBOList = (postBOInst as PostBO).GetBOAllPostsByUserId(userViewModel.IdUser);
                var postViewModelList = mapper.Map<List<PostViewModel>>(postBOList);
                return Ok(postViewModelList);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
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
            //var categoryBO = mapper.ServiceCtor.Invoke(typeof(CategoryBO));
            //try
            //{
            //    var categoryBOList = (categoryBO as CategoryBO).CategoryBOList();
            //    var categoryViewModelList = mapper.Map<List<CategoryViewModel>>(categoryBOList);
            //    return 
            //}
            //catch (Exception)
            //{
            //}


            //ViewBag.CategoryList = new SelectList(categoryViewModelList, "IdCategory", "CategoryName");
            //return PartialView();
        }
        //[HttpGet]
        //public HttpResponseMessage GetPostImage()
        //{
        //    return Request.CreateResponse(HttpStatusCode.OK);
        //}

        [HttpPost]
        [ActionName("Create")]
        public IHttpActionResult CreateContent()
        {
            var category = HttpContext.Current.Request.Params["category"];
            var content = HttpContext.Current.Request.Params["content"];
            var image = HttpContext.Current.Request.Files.Get(0);
            try
            {
                var userBO = mapper.ServiceCtor.Invoke(typeof(UserBO)) as UserBO;
                var postBO = mapper.ServiceCtor.Invoke(typeof(PostBO)) as PostBO;
                var postViewModel = mapper.Map<PostViewModel>(postBO);
                postViewModel.IdCategory = int.Parse(category);
                var userBOId = userBO.GetUserBOId(User.Identity.Name);
                postViewModel.IdUser = userBOId;
                if (image != null)
                {
                    postViewModel.PostImage = new byte[image.ContentLength];
                    image.InputStream.Read(postViewModel.PostImage, 0, image.ContentLength);
                }
                else
                {

                    byte[] defPhoto = System.IO.File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/Content/images/default-post-image.jpg"));
                    postViewModel.PostImage = new byte[Buffer.ByteLength(defPhoto)];
                    postViewModel.PostImage = defPhoto;
                }
                postViewModel.PostDate = DateTime.Now;
                var post = mapper.Map<PostBO>(postViewModel);
                post.SaveBO();
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
        [HttpGet]
        [ActionName("Post")]
        public IHttpActionResult GetPost(int id)
        {
            try
            {
                var postBO = mapper.ServiceCtor.Invoke(typeof(PostBO));
                var postsBOList = (postBO as PostBO).GetBOPostById(id);
                var postsViewModelList = mapper.Map<PostViewModel>(postsBOList);
                return Ok(postsViewModelList);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
