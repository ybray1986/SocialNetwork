using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.WEB.ViewModels
{
    public class UserFollowerViewModel
    {
        public UserViewModel IdUser1 { get; set; }
        public UserViewModel IdUser2 { get; set; }
    }
}
