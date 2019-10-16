using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork.WEB.ViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public byte[] Photo { get; set; }
        public DateTime RegisteredDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public Guid ActivationCode { get; set; }
        public virtual ICollection<RoleViewModel> Roles { get; set; }
    }
}