using AutoMapper;
using SocialNetwork.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BL.ModelBO
{
    public class PostBO:BusinessObjectBase
    {
        public int IdPost { get; set; }
        public string Title { get; set; }
        public string PostContent { get; set; }
        public bool? TypePublic { get; set; }
        public CategoryBO IdCategory { get; set; }
        public DateTime? PostDate { get; set; }
        public byte [] PostImage { get; set; }
        public UserBO IdUser { get; set; }

        public PostBO(IMapper mapperParam, UnitOfWorkFactory unitOfWorkFactoryParam) : base(mapperParam, unitOfWorkFactoryParam)
        {
        }

        void AddEditBO(IUnitOfWork unitOfWork)
        {
            var post = mapper.Map<DAL.Entities.Post>(this);
            unitOfWork.PostUOWRepository.Add(post);
            unitOfWork.Save();
        }
        public void SaveBO()
        {
            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                AddEditBO(unitOfWork);
            }
        }
        public void DeleteBO(int id)
        {
            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                unitOfWork.PostUOWRepository.Delete(id);
            }
        }
        public List<PostBO> GetBOAllPostsByUserId(int userId)
        {
            List<PostBO> posts = new List<PostBO>();
            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                var p = unitOfWork.PostUOWRepository.GetAll();
            }
            return posts;
        }
    }
}
