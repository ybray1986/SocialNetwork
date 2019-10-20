using SocialNetwork.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace SocialNetwork.BL.Providers
{
    public class CustomRoleProvider : RoleProvider
    {

        public override string[] GetRolesForUser(string userName)
        {
            string[] roles = new string[] { };
            using (SocialNetworkContext db = new SocialNetworkContext())
            {
                User user = db.Users.Where(u => u.UserName == userName).FirstOrDefault();
                if (user != null)
                {
                    roles = new string[] { user.Role.RoleName };
                }
                return roles;
            }
        }

        public override bool IsUserInRole(string userName, string roleName)
        {
            using (SocialNetworkContext db = new SocialNetworkContext())
            {
                User user = db.Users.Where(u => u.UserName == userName).FirstOrDefault();
                if (user != null && user.Role.RoleName == roleName)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public override string ApplicationName { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}