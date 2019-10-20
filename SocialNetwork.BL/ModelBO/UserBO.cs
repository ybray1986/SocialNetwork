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
    public class UserBO: BusinessObjectBase
    {
        public int IdUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateBirth { get; set; }
        public string Email { get; set; }
        public CountryBO IdCountry { get; set; }
        public string Gender { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public byte[] UserImage { get; set; }
        public int FirstLogin { get; set; }
        public bool NotificationEmails { get; set; }
        public bool NotificationPostLikers { get; set; }
        public bool NotificationPostComments { get; set; }
        public RoleBO Role { get; set; }

        public UserBO(IMapper mapperParam, UnitOfWorkFactory unitOfWorkFactoryParam) : base(mapperParam, unitOfWorkFactoryParam)
        {
        }
        public List<UserBO> GetBOListUsers()
        {
            List<UserBO> users = new List<UserBO>();
            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                users = unitOfWork.UserUOWRepository.GetAll().Select(model => mapper.Map<UserBO>(model)).ToList();
            }

            return users;
        }
        public UserBO GetUserBOById(int id)
        {
            UserBO user;
            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                user = unitOfWork.UserUOWRepository.GetAll().Where(i => i.IdUser == id).Select(model => mapper.Map<UserBO>(model)).FirstOrDefault();
            }
            return user;
        }
        void AddEditBO(IUnitOfWork unitOfWork)
        {
            var user = mapper.Map<DAL.Entities.User>(this);
            unitOfWork.UserUOWRepository.Add(user);
            unitOfWork.Save();
        }
        public void SaveBO()
        {
            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                AddEditBO(unitOfWork);
            }
        }

        public UserBO GetUserBOByLogin(string userName)
        {
            UserBO user;

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                user = unitOfWork.UserUOWRepository.GetAll().Where(a => a.UserName == userName).Select(item => mapper.Map<UserBO>(item)).FirstOrDefault();
            }
            return user;
        }
        public bool isValid(string userName, string password)
        {
            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                return unitOfWork.UserUOWRepository.GetAll().Where(user => user.UserName == userName && user.UserPassword == password).Any();
            }
        }
    }
}
