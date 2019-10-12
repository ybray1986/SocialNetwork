using AutoMapper;
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
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Photo { get; set; }
        public DateTime RegisteredDate { get; set; }
        //bind construct to get data from unitOfWork
        public UserBO(IMapper mapperParam, UnitOfWorkFactory unitOfWorkFactoryParam) : base(mapperParam, unitOfWorkFactoryParam)
        {
        }
        public List<UserBO> GetListUsers()
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
        public void Edit(AppUser model)
        {
            using (AuthDbContext db = new AuthDbContext())
            {
                var result = db.AppUsers.SingleOrDefault(item => item.UserId == model.UserId);
                if (result != null)
                {
                    db.Entry(result).CurrentValues.SetValues(model);
                    db.SaveChanges();
                }
            }
        }
        public AppUser GetUserByEmail(AppUser model)
        {
            using (AuthDbContext db = new AuthDbContext())
            {
                var user = db.AppUsers.Where(name => name.Email == model.Email).FirstOrDefault();
                return user;
            }
        }
        public bool isValid(string email, string password)
        {
            using (AuthDbContext db = new AuthDbContext())
            {
                var user = db.AppUsers.Where(l => l.Email == email && l.Password == password).FirstOrDefault();
                if (user != null)
                {
                    return true;
                }
                return false;
            }
        }
    }
}