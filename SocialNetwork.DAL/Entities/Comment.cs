﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Entities
{
    public class Comment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdComment { get; set; }
        public string CommentText { get; set; }
        public int? IdPost { get; set; }
        public int? IdUser { get; set; }
        public DateTime? CommentDate { get; set; }
    }
}
