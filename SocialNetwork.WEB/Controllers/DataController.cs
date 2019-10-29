using AutoMapper;
using SocialNetwork.BL.ModelBO;
using SocialNetwork.WEB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace SocialNetwork.WEB.Controllers
{
    [RoutePrefix("Home/web/Data")]
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
        [HttpGet]
        public IHttpActionResult GetUserId(int postId)
        {
            try
            {
                var post = mapper.ServiceCtor.Invoke(typeof(PostBO)) as PostBO;
                var postBO = post.GetBOPostById(postId);
                var postViewModel = mapper.Map<PostViewModel>(postBO);
                return Ok(postViewModel.IdUser);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
        [HttpPost]
        [ActionName("UserImage")]
        public IHttpActionResult GetUserImage([FromBody] byte[] image)
        {
            HttpResponseMessage message = new HttpResponseMessage();
            try
            {
                message.Content = new ByteArrayContent(image);
                message.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
                return Ok(message);
            }
            catch (Exception)
            {
                byte[] defPhoto = System.IO.File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/Content/photo/Users/default/default-24.png"));
                message.Content = new ByteArrayContent(defPhoto);
                message.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
                return Content(HttpStatusCode.OK, message);
            }
        }
        [HttpGet]
        [ActionName("UserName")]
        public IHttpActionResult GetUserName(int id)
        {
            var userBO = mapper.ServiceCtor(typeof(UserBO));
            var userBOList = (userBO as UserBO).GetUserBOById(id);
            var user = mapper.Map<UserViewModel>(userBOList);
            return Ok(user);
        }
        [HttpGet]
        [ActionName("CategoryList")]
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
        [HttpGet]
        [ActionName("CatName")]
        public IHttpActionResult GetCategory(int id)
        {
            try
            {
                var categoryBO = mapper.ServiceCtor(typeof(CategoryBO));
                var categoryBOList = (categoryBO as CategoryBO).GetCategoryBOById(id);
                var category = mapper.Map<CategoryViewModel>(categoryBOList);
                return Ok(category);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
        [HttpPost]
        [ActionName("PostImage")]
        public IHttpActionResult GetPostImage([FromBody]byte[] image)
        {
            HttpResponseMessage message = new HttpResponseMessage();
            try
            {
                message.Content = new ByteArrayContent(image);
                message.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
                return Ok(message);
            }
            catch (Exception)
            {
                byte[] defPhoto = System.IO.File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/Content/images/default-post-image.jpg"));
                message.Content = new ByteArrayContent(defPhoto);
                message.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
                return Ok(message);
            }
        }
        [HttpGet]
        [ActionName("Likes")]
        public IHttpActionResult GetPostLikes(int id)
        {
            return Ok();
        }
        [HttpPost]
        public IHttpActionResult PostComment()
        {
            var text = HttpContext.Current.Request.Params["text"];
            var postId = HttpContext.Current.Request.Params["postId"];
            try
            {
                var user = mapper.ServiceCtor.Invoke(typeof(UserBO)) as UserBO;
                var userBOId = user.GetUserBOId(User.Identity.Name);
                var comment = mapper.ServiceCtor.Invoke(typeof(CommentViewModel)) as CommentViewModel;
                comment.IdPost = int.Parse(postId);
                comment.IdUser = userBOId;
                comment.CommentText = text;
                comment.CommentDate = DateTime.Now;
                var commentBO = mapper.Map<CommentBO>(comment);
                commentBO.SaveBO();
                return Ok(comment);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
        [HttpGet]
        [ActionName("Comments")]
        public IHttpActionResult GetPostComments(int id)
        {
            try
            {
                var comment = mapper.ServiceCtor.Invoke(typeof(CommentBO)) as CommentBO;
                var commentBOList = comment.GetComments(id);
                var commentViewModelList = mapper.Map<List<CommentViewModel>>(commentBOList);
                commentViewModelList.Sort(delegate (CommentViewModel x, CommentViewModel y)
                {
                    if (x.CommentDate == null && y.CommentDate == null) return 0;
                    else if (x.CommentDate == null) return -1;
                    else if (y.CommentDate == null) return 1;
                    else return DateTime.Compare(x.CommentDate.GetValueOrDefault(), y.CommentDate.GetValueOrDefault());
                });
                return Ok(commentViewModelList);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
        
    }
}
