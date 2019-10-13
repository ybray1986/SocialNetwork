using AutoMapper;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BL.ModelBO
{
    public class UserBO : BusinessObjectBase
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Photo { get; set; }
        public DateTime RegisteredDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public Guid ActivationCode { get; set; }
        public virtual ICollection<AppRole> Roles { get; set; }
        //Bind construct to get data from unitOfWork
        public UserBO(IMapper mapperParam, UnitOfWorkFactory unitOfWorkFactoryParam) : base(mapperParam, unitOfWorkFactoryParam)
        {
        }
        public List<UserBO> GetBOListUsers()
        {
            List<UserBO> users = new List<UserBO>();
            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                users = unitOfWork.UserWoURepository.GetAll().Select(model => mapper.Map<UserBO>(model)).ToList();
            }

            return users;
        }
        public UserBO GetUserBOById(int id)
        {
            UserBO user;
            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                user = unitOfWork.UserWoURepository.GetAll().Where(i => i.UserId == id).Select(model => mapper.Map<UserBO>(model)).FirstOrDefault();
            }
            return user;
        }
        void AddEditBO(IUnitOfWork unitOfWork)
        {
            var user = mapper.Map<AppUser>(this);
            unitOfWork.UserWoURepository.Add(user);
            unitOfWork.Save();
        }
        public void SaveBO()
        {
            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                AddEditBO(unitOfWork);
            }
        }

        public UserBO GetUserBOByEmail(string email)
        {
            UserBO user;

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                user = unitOfWork.UserWoURepository.GetAll().Where(a => a.Email == email).Select(item => mapper.Map<UserBO>(item)).FirstOrDefault();
            }
            return user;
        }
        public bool isValid(string email, string password)
        {
            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                return unitOfWork.UserWoURepository.GetAll().Where(user => user.Email == email && user.Password == password).Any();
            }
        }
    }
}