using SocialNetwork.AUTH.Entities;
using System.Collections.Generic;
using System.Web.Security;

namespace SocialNetwork.AUTH.Infrastucture
{
    public class CustomMembershipUser
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<AppRole> Roles { get; set; }
        public CustomMembershipUser(AppUser user)
        {
            UserId = user.UserId;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Roles = user.Roles;
        }
    }
}