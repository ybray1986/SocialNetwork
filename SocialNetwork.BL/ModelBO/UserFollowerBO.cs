using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BL.ModelBO
{
    public class UserFollowerBO
    {
        public UserBO IdUser1 { get; set; }
        public UserBO IdUser2 { get; set; }
    }
}
