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
    [Authorize]
    public class HomeController : Controller
    {
        private IMapper mapper;
        public HomeController(IMapper mapperParam)
        {
            mapper = mapperParam;
        }
        public ActionResult Index()
        {
            ViewBag.GetUserName = new Func<int, string>(GetUserName);
            ViewBag.GetCategoryName = new Func<int, string>(GetCategory);
            return View();
        }
        public ActionResult Notification()
        {
            return PartialView();
        }
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
        public ActionResult Search()
        {
            var userBO = mapper.ServiceCtor(typeof(UserBO));
            var model = (userBO as UserBO).GetBOListUsers().Select(item=>mapper.Map<UserViewModel>(item)).ToList();
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
    }
}