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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(AppUser model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AppUser> GetListUsers()
        {
            throw new NotImplementedException();
        }

        public AppUser GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public bool isValid(string login, string password)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
