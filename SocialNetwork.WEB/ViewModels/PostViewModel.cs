using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.WEB.ViewModels
{
    public class PostViewModel
    {
        public int IdPost { get; set; }
        public string Title { get; set; }
        public string PostContent { get; set; }
        public bool TypePublic { get; set; }
        public CategoryViewModel IdCategory { get; set; }
        public DateTime PostDate { get; set; }
        public byte [] PostImage { get; set; }
        public UserViewModel IdUser { get; set; }
    }
}
