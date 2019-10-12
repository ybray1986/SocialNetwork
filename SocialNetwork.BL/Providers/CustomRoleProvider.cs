using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace SocialNetwork.BL.Providers
{
    public class CustomRoleProvider:RoleProvider
    {
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

        public override string[] GetRolesForUser(string email)
        {
            string[] roles = new string[] { };
            using (AuthDbContext db = new AuthDbContext())
            {
                AppUser user = db.AppUsers.Where(u => u.Email == email).FirstOrDefault();
                if (user != null)
                {
                    roles = user.Roles.Select(r => r.RoleName).ToArray();
                }
                return roles;
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string email, string roleName)
        {
            using (AuthDbContext db = new AuthDbContext())
            {
                // Получаем пользователя
                AppUser user = db.AppUsers.Where(u => u.Email == email).FirstOrDefault();

                if (user != null && user.Roles.Contains(new AppRole { RoleName = roleName }))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
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