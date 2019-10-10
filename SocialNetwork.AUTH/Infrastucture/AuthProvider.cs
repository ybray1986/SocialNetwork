using SocialNetwork.AUTH.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.AUTH.Infrastucture
{
    public class AuthProvider : IAuthProvider
    {

        public void Add(AppUser model)
        {
            using (AuthDbContext db = new AuthDbContext())
            {
                db.AppUsers.Add(model);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using(AuthDbContext db = new AuthDbContext())
            {
                var user = db.AppUsers.Find(id);
                db.AppUsers.Remove(user);
                db.SaveChanges();
            }
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

        public IEnumerable<AppUser> GetListUsers()
        {
            using (AuthDbContext db = new AuthDbContext())
            {
                return db.AppUsers.ToList();
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

        public AppUser GetUserById(int id)
        {
            using(AuthDbContext db = new AuthDbContext())
            {
                return db.AppUsers.Find(id);
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
