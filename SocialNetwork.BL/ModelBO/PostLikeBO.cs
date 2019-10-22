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
        public int? IdPost { get; set; }
        public int? IdUser { get; set; }
    }
}
