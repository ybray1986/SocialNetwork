using SocialNetwork.AUTH.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SocialNetwork.AUTH.Infrastucture
{
    public class CustomRoleProvider : ICustomRoleProvider
    {
        public string[] GetRolesForUser(string userName)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }

            var userRoles = new string[] { };

            using (AuthDbContext dbContext = new AuthDbContext())
            {
                var selectedUser = (from us in dbContext.AppUsers.Include("Roles")
                                    where string.Compare(us.UserName, userName, StringComparison.OrdinalIgnoreCase) == 0
                                    select us).FirstOrDefault();

                if (selectedUser != null)
                {
                    userRoles = new[] { selectedUser.Roles.Select(r => r.RoleName).ToString() };
                }
                return userRoles.ToArray();
            }
        }

        public bool IsUserInRole(string userName, string roleName)
        {
            var userRoles = GetRolesForUser(userName);
            return userRoles.Contains(roleName);
        }
    }
}
