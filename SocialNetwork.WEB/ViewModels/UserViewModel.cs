﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.WEB.ViewModels
{
    public class UserViewModel
    {
        public int IdUser { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DataType DateBirth { get; set; }
        [Required]
        public string Email { get; set; }
        public int IdCountry { get; set; }
        public string Gender { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserPassword { get; set; }
        public byte[] UserImage { get; set; }
        public int FirstLogin { get; set; }
        public bool NotificationEmails { get; set; }
        public bool NotificationPostLikers { get; set; }
        public bool NotificationPostComments { get; set; }
        public RoleViewModel Role { get; set; }
    }
}
