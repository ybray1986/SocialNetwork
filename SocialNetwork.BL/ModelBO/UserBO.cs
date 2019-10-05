using AutoMapper;
using SocialNetwork.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BL.ModelBO
{
    public class UserBO
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Photo { get; set; }
        public DateTime RegisteredDate { get; set; }

        IMapper mapper;
        //bind construct to get data from unitOfWork
        public UserBO() { }
        public UserBO(IMapper mapperParam)
        {
            mapper = mapperParam;
        }

        public List<UserBO> GetListUsers()
        {
            List<UserBO> users = new List<UserBO>();
            using (var unitOfWork = UnitOfWorkFactory.Create())
            {
                users = unitOfWork.UserWoURepository.GetAll().Select(model => mapper.Map<UserBO>(model)).ToList();
            }

            return users;
        }
        public UserBO GetUserBOById(int id)
        {
            UserBO user;
            using (var unitOfWork = UnitOfWorkFactory.Create())
            {
                user = unitOfWork.UserWoURepository.GetAll().Where(i => i.Id == id).Select(model => mapper.Map<UserBO>(model)).FirstOrDefault();
            }
            return user;
        }
    }
}