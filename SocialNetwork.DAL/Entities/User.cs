using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Entities
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateBirth { get; set; }
        public string Email { get; set; }
        public virtual Country IdCountry { get; set; }
        public string Gender { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public byte[] UserImage { get; set; }
        public int? FirstLogin { get; set; }
        public bool? NotificationEmails { get; set; }
        public bool? NotificationPostLikers { get; set; }
        public bool? NotificationPostComments { get; set; }
        public virtual Role Role { get; set; }

    }
}
