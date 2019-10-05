using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.AUTH.Entities
{
    public class AppRole
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<AppUser> Users { get; set; }
    }
}
