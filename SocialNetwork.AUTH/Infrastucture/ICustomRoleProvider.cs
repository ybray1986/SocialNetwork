using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.AUTH.Infrastucture
{
    interface ICustomRoleProvider
    {
        bool IsUserInRole(string userName, string roleName);
        string[] GetRolesForUser(string userName);
    }
}
