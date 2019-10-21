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
    public class CommentBO: BusinessObjectBase
    {
        public int IdComment { get; set; }
        public string CommentText { get; set; }
        public PostBO IdPost { get; set; }
        public UserBO IdUser { get; set; }
        public DateTime? CommentDate { get; set; }

        public CommentBO(IMapper mapperParam, UnitOfWorkFactory unitOfWorkFactoryParam) : base(mapperParam, unitOfWorkFactoryParam)
        {
        }
        public List<CommentBO> GetComments(int idPost)
        {
            List<CommentBO> comments = new List<CommentBO>();
            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                comments = unitOfWork.CommentUOWRepository.GetAll().Where(item=>item.IdPost.IdPost == idPost).Select(model => mapper.Map<CommentBO>(model)).ToList();
            }
            return comments;
        }
        public void SaveBO()
        {
            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                AddEditBO(unitOfWork);
            }
        }

        private void AddEditBO(IUnitOfWork unitOfWork)
        {
            var comment = mapper.Map<DAL.Entities.Comment>(this);
            unitOfWork.CommentUOWRepository.Add(comment);
            unitOfWork.Save();
        }
    }
}
