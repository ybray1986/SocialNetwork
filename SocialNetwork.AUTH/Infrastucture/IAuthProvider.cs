using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.AUTH.Infrastucture
{
    public interface IAuthProvider<T> where T:class
    {
        bool isValid(string login, string password);
        void Add(T model);
        T GetUserById(int id);
        IEnumerable<T> GetListUsers();
        void Edit(T model);
        void Delete(int id);
        void Save();
    }
}
