using System.Collections.Generic;

namespace SocialNetwork.BL.ModelBO
{
    public class RoleBO
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public List<UserBO> Users { get; set; }
    }
}