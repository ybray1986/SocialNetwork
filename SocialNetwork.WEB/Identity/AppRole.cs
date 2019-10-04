using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork.WEB.Identity
{
    public class AppRole : IdentityRole
    {
        public AppRole(string roleName) : base(roleName)
        {
        }
    }
}