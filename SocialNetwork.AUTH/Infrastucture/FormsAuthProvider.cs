using SocialNetwork.AUTH.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace SocialNetwork.AUTH.Infrastucture
{
    public class FormsAuthProvider : IAuthProvider
    {
        public bool Authenticate(string userName, string password)
        {
            bool result = FormsAuthentication.Authenticate(userName, password);
            if (result) { FormsAuthentication.SetAuthCookie(userName, false); return result; }
            
            using (AuthDbContext dbContext = new AuthDbContext())
            {
                var user = (from us in dbContext.AppUsers
                            where string.Compare(userName, us.UserName, StringComparison.OrdinalIgnoreCase) == 0
                            && string.Compare(password, us.Password, StringComparison.OrdinalIgnoreCase) == 0
                            && us.IsActive == true
                            select us).FirstOrDefault();

                return (user != null) ? true : false;
            }
        }
        public CustomMembershipUser GetUser(string userName)
        {
            using (AuthDbContext dbContext = new AuthDbContext())
            {
                var user = (from us in dbContext.AppUsers
                            where string.Compare(userName, us.UserName, StringComparison.OrdinalIgnoreCase) == 0
                            select us).FirstOrDefault();

                if (user == null)
                {
                    return null;
                }
                var selectedUser = new CustomMembershipUser(user);

                return selectedUser;
            }
        }

        public string GetUserNameByEmail(string eMail)
        {
            using (AuthDbContext dbContext = new AuthDbContext())
            {
                string userName = (from u in dbContext.AppUsers
                                   where string.Compare(eMail, u.Email) == 0
                                   select u.UserName).FirstOrDefault();

                return !string.IsNullOrEmpty(userName) ? userName : string.Empty;
            }
        }
    }
}
