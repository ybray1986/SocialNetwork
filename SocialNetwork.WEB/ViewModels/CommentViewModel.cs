using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.WEB.ViewModels
{
    public class CommentViewModel
    {
        public int IdComment { get; set; }
        public string CommentText { get; set; }
        public int IdPost { get; set; }
        public int IdUser { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
