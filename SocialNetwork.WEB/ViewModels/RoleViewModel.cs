using System.Collections.Generic;

namespace SocialNetwork.WEB.ViewModels
{
    public class RoleViewModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<UserViewModel> Users { get; set; }
    }
}