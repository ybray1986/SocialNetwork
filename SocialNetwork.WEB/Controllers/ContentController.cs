using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialNetwork.WEB.Controllers
{
    public class ContentController : ApiController
    {
        //Get Data: Add, Edit, Delete posts. Get all UserName Post to Index
        //Get Posts From Followers
        //View Posts from Users of Search list
        //Posts count
        public ActionResult AddContent()
        {
            var categoryBO = mapper.ServiceCtor.Invoke(typeof(CategoryBO));
            var categoryBOList = (categoryBO as CategoryBO).CategoryBOList();
            var categoryViewModelList = mapper.Map<List<CategoryViewModel>>(categoryBOList);
            ViewBag.CategoryList = new SelectList(categoryViewModelList, "IdCategory", "CategoryName");
            return PartialView();
        }
        [HttpPost]
        public ActionResult AddContent(PostViewModel postParam, HttpPostedFileBase image)
        {
            var userBO = mapper.ServiceCtor.Invoke(typeof(UserBO));
            var userBOList = (userBO as UserBO).GetUserBOByLogin(User.Identity.Name);
            var userViewModel = mapper.Map<UserViewModel>(userBOList);
            postParam.IdUser = userViewModel.IdUser;
            if (image != null)
            {
                postParam.PostImage = new byte[image.ContentLength];
                image.InputStream.Read(postParam.PostImage, 0, image.ContentLength);
            }
            else
            {

                byte[] defPhoto = System.IO.File.ReadAllBytes(Server.MapPath("~/Content/images/default-post-image.jpg"));
                postParam.PostImage = new byte[Buffer.ByteLength(defPhoto)];
                postParam.PostImage = defPhoto;
            }
            var post = mapper.Map<PostBO>(postParam);
            post.SaveBO();
            return RedirectToAction("Index");
        }
        public ActionResult GetCurrentUserIdPosts()
        {
            var userBO = mapper.ServiceCtor.Invoke(typeof(UserBO));
            var userBOList = (userBO as UserBO).GetUserBOByLogin(User.Identity.Name);
            var userViewModel = mapper.Map<UserViewModel>(userBOList);
            var userId = userViewModel.IdUser;
            var postBO = mapper.ServiceCtor.Invoke(typeof(PostBO));
            var postsBOUser = (postBO as PostBO).GetBOAllPostsByUserId(userId);
            var postsViewModelList = postsBOUser.Select(model => mapper.Map<PostViewModel>(model)).ToList();
            return PartialView("Posts", postsViewModelList);
        }
    }
}
