using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BL.ModelBO
{
    public class PostBO
    {
        public int IdPost { get; set; }
        public string Title { get; set; }
        public string PostContent { get; set; }
        public bool TypePublic { get; set; }
        public int IdCategory { get; set; }
        public DateTime PostDate { get; set; }
        public byte [] PostImage { get; set; }
        public int IdUser { get; set; }
    }
}
