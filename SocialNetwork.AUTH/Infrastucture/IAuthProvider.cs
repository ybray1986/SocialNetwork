using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace SocialNetwork.AUTH.Infrastucture
{
    public interface IAuthProvider
    {
        bool Authenticate(string userName, string password);
        CustomMembershipUser GetUser(string userName);
        string GetUserNameByEmail(string eMail);
    }
}
