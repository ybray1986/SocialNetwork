using System.Collections.Generic;

namespace SocialNetwork.WEB.ViewModels
{
    public class RoleViewModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public List<UserViewModel> Users { get; set; }
    }
}