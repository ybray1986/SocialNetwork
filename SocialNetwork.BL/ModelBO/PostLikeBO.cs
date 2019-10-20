using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BL.ModelBO
{
    public class PostLikeBO
    {
        public PostBO IdPost { get; set; }
        public UserBO IdUser { get; set; }
    }
}
